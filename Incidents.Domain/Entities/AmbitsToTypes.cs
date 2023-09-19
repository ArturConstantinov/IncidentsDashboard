using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidents.Domain.Entities
{
    public class AmbitsToTypes
    {
        public int AmbitId { get; set; }
        public int TypeId { get; set; }
        public Ambit IncidentAmbit { get; set; }
        public IncidentType IncidentType { get; set; }
    }
}
