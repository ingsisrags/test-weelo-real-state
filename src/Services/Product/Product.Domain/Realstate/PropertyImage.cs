using Common.Utilities.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Product.Domain.Realstate
{
    [Table("PropertyImage")]
    public class PropertyImage : Entity<Guid>
    {
        public string File { get; set; }
        public bool Enabled { get; set; }

        public Guid PropertyId { get; set; }
        public Property Property { get; set; }
        public int Order { get; set; }
    }
}
