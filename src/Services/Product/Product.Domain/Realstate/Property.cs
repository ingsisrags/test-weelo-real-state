using Common.Utilities.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Product.Domain.Realstate
{
    [Table("Property")]
    public class Property : Entity<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(10)]
        public string CodeInternal { get; set; }
        public int Year { get; set; }
        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }
        public List<PropertyTrace> PropertyTraces {get;set;}
        public PropertyImage PropertyImage {get;set;}
}
}
