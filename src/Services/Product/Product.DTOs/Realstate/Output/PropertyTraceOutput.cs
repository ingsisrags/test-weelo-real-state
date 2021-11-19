using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.DTOs.Realstate.Output
{
    public class PropertyTraceOutput
    {
        public DateTime DateSale { get; set; }
        public string Name { get; set; }

        public double Value { get; set; }
        public double Tax { get; set; }
    }
}
