

using Microsoft.EntityFrameworkCore;
using Product.Domain.Realstate;
using System;

namespace Product.Persistence.Database.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<PropertyImage> PropertyImage { get; set; }
        public virtual DbSet<PropertyTrace> PropertyTrace { get; set; }
       
    }
}
