

using Microsoft.EntityFrameworkCore;
using System;

namespace Product.Persistence.Database.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<Domain.Farming.Grow.GrowUnit> GrowUnits { get; set; }
       
    }
}
