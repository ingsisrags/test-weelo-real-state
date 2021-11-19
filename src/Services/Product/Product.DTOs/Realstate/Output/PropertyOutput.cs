using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.DTOs.Realstate.Output
{
    public class PropertyOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public string Address { get; set; }
        public string CodeInternal { get; set; }
        public int Year { get; set; }
        public OwnerOutput Owner { get; set; }

        public List<ImageOutput> PropertyImage { get; set; }
        public List<PropertyTraceOutput> PropertyTraces { get; set; }
    }
}
