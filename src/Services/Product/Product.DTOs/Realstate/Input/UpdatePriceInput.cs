using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.DTOs.Realstate.Input
{
    public class UpdatePriceInput
    {
        [Required]
        public double Price { get; set; }
        [Required]
        public Guid PropertyId { get; set; }
    }
}
