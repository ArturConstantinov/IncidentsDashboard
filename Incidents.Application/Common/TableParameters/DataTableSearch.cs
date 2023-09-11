using System.Runtime.Serialization;

namespace Incidents.Application.Common.TableParameters
{
    [Serializable]
    [DataContract]
    public class DataTablesSearch
    {
        public DataTablesSearch()
        {
            Values = new List<string>();
        }

        [DataMember(Name = "value")]
        public string Value { get; set; }

        public ICollection<string> Values { get; set; }

        [DataMember(Name = "regex")]
        public string Regex { get; set; }
    }
}