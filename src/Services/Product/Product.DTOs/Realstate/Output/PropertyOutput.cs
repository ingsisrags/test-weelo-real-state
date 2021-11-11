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

        public List<PropertyViewOrderOutput> PropertyImage { get; set; }
    }
}
