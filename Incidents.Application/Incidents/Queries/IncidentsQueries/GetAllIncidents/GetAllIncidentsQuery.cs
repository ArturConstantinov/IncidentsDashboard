﻿using Incidents.Application.Common.Interfaces;
using Incidents.Application.Common.TableParameters;
using Incidents.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Incidents.Application.Incidents.Queries.IncidentsQueries.GetAllIncidents
{
    public class GetAllIncidentsQuery : IRequest<GetAllIncidentsVm>
    {
        public DataTablesParameters Parameters { get; set; }

        public GetAllIncidentsQuery(DataTablesParameters parameters)
        {
            Parameters = parameters;
        }
    }

    public class GetAllIncidentsQueryHandler : IRequestHandler<GetAllIncidentsQuery, GetAllIncidentsVm>
    {
        private readonly IIncidentsDbContext _context;

        public GetAllIncidentsQueryHandler(IIncidentsDbContext context)
        {
            _context = context;
        }

        public async Task<GetAllIncidentsVm> Handle(GetAllIncidentsQuery request, CancellationToken cancellationToken)
        {
            string orderColumn = request.Parameters.Columns[request.Parameters.Order[0].Column].Name;
            string search = request.Parameters.Search.Value ?? "";

            IQueryable<Incident> incidentQuery = _context.Incidents;

            Expression<Func<Incident, object>> orderKey = request.Parameters.Columns[request.Parameters.Order[0].Column].Data switch
            {
                "requestNr" => incident => incident.RequestNr,
                "subsystem" => incident => incident.Subsystem,
                "openDate" => incident => incident.OpenDate,
                "closeDate" => incident => incident.CloseDate,
                "type" => incident => incident.Type,
                "urgency" => incident => incident.Urgency,
                _ => incident => incident.Id
            };

            if (request.Parameters.Order[0].Dir == "desc")
            {
                incidentQuery = incidentQuery.OrderByDescending(orderKey);
            }
            else
            {
                incidentQuery = incidentQuery.OrderBy(orderKey);
            }

            var incidents = await incidentQuery
                .Where(x => x.RequestNr.ToLower().Contains(search)
                || x.Subsystem.ToLower().Contains(search)
                || x.OpenDate.ToString().ToLower().Contains(search)
                || x.CloseDate.ToString().ToLower().Contains(search)
                || x.Type.ToLower().Contains(search)
                || x.Urgency.ToLower().Contains(search))
                .Skip(request.Parameters.Start)
                .Take(request.Parameters.Length)
                .Select(x => new GetAllIncidentsDto
                {
                    Id = x.Id,
                    RequestNr = x.RequestNr,
                    Subsystem = x.Subsystem,
                    OpenDate = x.OpenDate,
                    CloseDate = x.CloseDate,
                    Type = x.Type,
                    Urgency = x.Urgency
                })
                .ToListAsync();

            var incidentsCount = await incidentQuery
                .Where(x => x.RequestNr.ToLower().Contains(search)
                    || x.Subsystem.ToLower().Contains(search)
                    || x.OpenDate.ToString().ToLower().Contains(search)
                    || x.CloseDate.ToString().ToLower().Contains(search)
                    || x.Type.ToLower().Contains(search)
                    || x.Urgency.ToLower().Contains(search))
                .CountAsync(cancellationToken);

            request.Parameters.TotalCount = incidentsCount;

            return new GetAllIncidentsVm { Incidents = incidents };
        }
    }
}