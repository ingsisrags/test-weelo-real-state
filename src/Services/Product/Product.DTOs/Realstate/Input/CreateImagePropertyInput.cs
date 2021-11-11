using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.DTOs.Realstate.Input
{
    public class CreateImagePropertyInput
    {
        /// <summary>
        ///  Image :  Image of property to create
        /// </summary>
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public Guid PropertyId { get; set; }
    }
}
