using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.DTOs.Realstate.Input
{
    public class CreatePropertyTrace
    {
        [Required]
        public DateTime DateSale { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Value { get; set; }
        [Required]
        public double Tax { get; set; }
    }
}
