using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidents.Domain.Entities
{
    public class OriginsToAmbit
    {
        public int OriginId { get; set; }
        public int AmbitId { get; set; }
        public Origin Origin { get; set; }
        public Ambit Ambit { get; set; }
    }
}
