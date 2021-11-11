using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.DTOs.Realstate.Input
{
    public class FilterPropertyInput 
    {
        /// <summary>
        /// Filter by product
        /// </summary>
        public Guid? ProductId { get; set; }

        /// <summary>
        /// Filter by min price
        /// </summary>
        public double? MinimumPrice { get; set; }

        /// <summary>
        /// Filter by max price
        /// </summary>
        public double? MaximumPrice { get; set; }
        public string? Keyword { get; set; }
        /// <summary>
        /// Pagination filter start value 1
        /// </summary>
        [Required]
        public int PageNumber { get; set; }


        /// <summary>
        /// Pagination filter
        /// </summary>
        [Required]
        public int PageSize { get; set; }
    }
}
