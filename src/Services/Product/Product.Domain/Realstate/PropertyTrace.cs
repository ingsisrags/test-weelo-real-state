using Common.Utilities.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Product.Domain.Realstate
{
    [Table("PropertyTrace")]
    public class PropertyTrace : Entity<Guid>
    {
        public DateTime DateSale { get; set; }
        public string Name { get; set; }

        public double Value { get; set; }
        public double Tax { get; set; }
        public Guid PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
