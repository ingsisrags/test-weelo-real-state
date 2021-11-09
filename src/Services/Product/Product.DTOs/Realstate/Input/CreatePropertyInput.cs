using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.DTOs.Realstate.Input
{
    public class CreatePropertyInput
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public double Price { get; set; }
        [StringLength(10)]
        [Required]
        public string CodeInternal { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public CreateOwnerInput Owner { get; set; }
        [Required]
        public CreatePropertyTrace PropertyTrace { get; set; }

    }
}
