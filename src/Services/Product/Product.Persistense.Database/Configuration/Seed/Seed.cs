using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Product.Persistence.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Persistense.Database.Configuration.Seed
{
    public class Seed
    {
        public async Task SeedAsync(ApplicationDbContext context, ILogger<ApplicationDbContext> logger,
          IConfiguration configuration)
        {
            try
            {
                Console.WriteLine("Creating strains");

              
            }
            catch (Exception ex)
            {
                logger.LogError("Migration error: " + ex, ex);
            }
        }
    }
}
