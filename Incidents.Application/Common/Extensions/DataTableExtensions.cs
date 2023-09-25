using Incidents.Application.Common.TableParameters;
using System.Linq.Expressions;

namespace Incidents.Application.Common.Extensions
{
    public static class DataTableExtensions
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> source, DataTablesParameters parameters)
        {
            parameters.TotalCount = source.Count();
            return source.Skip(parameters.Start).Take(parameters.Length);
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, DataTablesParameters parameters)
        {
            parameters.SetColumnName();
            var expression = source.Expression;
            var count = 0;
            foreach (var item in parameters.Order)
            {
                ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
                MemberExpression selector = Expression.PropertyOrField(parameter, item.Name);
                string orderAsc = count == 0 ? nameof(Queryable.OrderBy) : nameof(Queryable.ThenBy);
                string orderDesc = count == 0 ? nameof(Queryable.OrderByDescending) : nameof(Queryable.ThenByDescending);
                string method = item.Dir.ToUpper() == "DESC" ? orderDesc : orderAsc;
                expression = Expression.Call(typeof(Queryable), method,
                    new Type[] { source.ElementType, selector.Type },
                    expression, Expression.Quote(Expression.Lambda(selector, parameter)));
                count++;
            }
            return count > 0 ? source.Provider.CreateQuery<T>(expression) : source;
        }

        public static IQueryable<T> Search<T>(this IQueryable<T> source, DataTablesParameters parameters)
        {
            string searchText = parameters.Search.Value;
            IEnumerable<string> columnNames = parameters.Columns.Where(x => x.Searchable).Select(x => x.Data);

            if (string.IsNullOrWhiteSpace(searchText) || !columnNames.Any())
            {
                return source;
            }

            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "x");
            Expression predicateBuilder = Expression.Constant(false);
            ConstantExpression constantExpression = Expression.Constant(searchText.ToUpper().Trim());

            foreach (string columnName in columnNames)
            {
                // (x.Member)
                MemberExpression memberExpression = Expression.Property(parameterExpression, columnName);

                if (memberExpression.Type != typeof(string))
                {
                    continue;
                }

                // (x.Member.ToUpper())
                Expression caseInsentitiveMemberExpression = Expression.Call(
                    memberExpression,
                    typeof(string).GetMethod(nameof(String.ToUpper), Type.EmptyTypes));

                // (x.Member.ToUpper().Contains(constantExpression))
                Expression containsMemberExpression = Expression.Call(
                    caseInsentitiveMemberExpression,
                    typeof(string).GetMethod(nameof(String.Contains), new[] { typeof(string) }),
                    constantExpression);

                predicateBuilder = Expression.OrElse(predicateBuilder, containsMemberExpression);
            }

            LambdaExpression lambdaExpression = Expression.Lambda(predicateBuilder, parameterExpression);

            Expression expression = source.Expression;
            expression = Expression.Call(
                typeof(Queryable),
                nameof(Queryable.Where),
                new Type[] { source.ElementType },
                expression,
                Expression.Quote(lambdaExpression));

            IQueryable<T> query = source.Provider.CreateQuery<T>(expression);
            return query;
        }

        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, bool> predicate)
        {
            if (condition)
                return source.Where(predicate);
            else
                return source;
        }

        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, int, bool> predicate)
        {
            if (condition)
                return source.Where(predicate);
            else
                return source;
        }

        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, bool>> predicate)
        {
            return condition
                ? source.Where(predicate)
                : source;
        }

        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, int, bool>> predicate)
        {
            return condition
                ? source.Where(predicate)
                : source;
        }

        static IEnumerable<TSource> DistinctByImpl<TSource, TKey>(IEnumerable<TSource> source,
              Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            HashSet<TKey> knownKeys = new HashSet<TKey>(comparer);
            foreach (TSource element in source)
            {
                if (knownKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}
