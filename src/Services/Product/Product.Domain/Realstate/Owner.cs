using Common.Utilities.Database;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Utilities.Core.Configuration.Database.Models;

namespace Product.Domain.Realstate
{
    [Table("Owner")]
    public class Owner : Entity<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
    }
}
