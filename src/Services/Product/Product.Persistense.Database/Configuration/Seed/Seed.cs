using Common.Utilities.FileUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Product.Persistence.Database.Context;
using System;
using System.Collections.Generic;
using System.IO;
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
                if (!context.Owner.Any())
                {
                    var rand = new Random();

                    var e1 = context.Owner.Add(new Domain.Realstate.Owner()
                    {
                        Address = "Street 72 Avenue 41 L.A.",
                        Birthday = DateTime.Parse("1981-10-08"),
                        Name = "Bill Stan",
                        Photo = FileUtilities.GetBase64FromPath(Path.Combine("Images/", "empresario1.jpg"))
                    });
                    var e2 = context.Owner.Add(new Domain.Realstate.Owner()
                    {
                        Address = "Street 76 Avenue 76 N.Y.",
                        Birthday = DateTime.Parse("1979-03-20"),
                        Name = "Will Top",
                        Photo = FileUtilities.GetBase64FromPath(Path.Combine("Images/", "empresario2.jpg"))
                    });
                    var e3 = context.Owner.Add(new Domain.Realstate.Owner()
                    {
                        Address = "Street 55 Avenue 98 M.M.",
                        Birthday = DateTime.Parse("1988-06-03"),
                        Name = "Nick Cheer",
                        Photo = FileUtilities.GetBase64FromPath(Path.Combine("Images/", "empresario3.jpg"))
                    });
                    var e4 = context.Owner.Add(new Domain.Realstate.Owner()
                    {
                        Address = "Street 78 Avenue 33 C.A.",
                        Birthday = DateTime.Parse("1973-12-01"),
                        Name = "Danny Houston",
                        Photo = FileUtilities.GetBase64FromPath(Path.Combine("Images/", "empresario4.jpg"))
                    });

                    var b1 = context.Property.Add(new Domain.Realstate.Property()
                    {
                        Name = "Building NY - Big Street",
                        Address = "Street 45 Avenue 86 N.Y.",
                        CodeInternal = "00001122",
                        Price = 12000000,
                        Year = 2022,
                        OwnerId = e1.Entity.Id
                    });

                    var b2 = context.Property.Add(new Domain.Realstate.Property()
                    {
                        Name = "Building LA - UNDERGROUND",
                        Address = "Street 35 Avenue 71 L.A.",
                        CodeInternal = "00001123",
                        Price = 19000000,
                        Year = 2023,
                        OwnerId = e3.Entity.Id
                    });
                    var b3 = context.Property.Add(new Domain.Realstate.Property()
                    {
                        Name = "Building CA - The Luxury",
                        Address = "Street 87 Avenue 32 C.A.",
                        CodeInternal = "00001123",
                        Price = 22000000,
                        Year = 2020,
                        OwnerId = e4.Entity.Id
                    });
                    var b4 = context.Property.Add(new Domain.Realstate.Property()
                    {
                        Name = "Building ALK - Big Cool",
                        Address = "Street 33 Avenue 78 A.L.",
                        CodeInternal = "00001123",
                        Price = 32000000,
                        Year = 2023,
                        OwnerId = e4.Entity.Id
                    });
                    var b5 = context.Property.Add(new Domain.Realstate.Property()
                    {
                        Name = "Building W. D.C - The Only One",
                        Address = "Street 87 Avenue 33 N.Y.",
                        CodeInternal = "00001124",
                        Price = 300000000,
                        Year = 2024,
                        OwnerId = e2.Entity.Id
                    });

                    var b6 = context.Property.Add(new Domain.Realstate.Property()
                    {
                        Name = "Building L.A - The big shop",
                        Address = "Street 33 Avenue 65 N.Y.",
                        CodeInternal = "00001126",
                        Price = 42000000,
                        Year = 2022,
                        OwnerId = e1.Entity.Id
                    });

                    var b7 = context.Property.Add(new Domain.Realstate.Property()
                    {
                        Name = "Building NY - The Electronic Since",
                        Address = "Street 76 Avenue 33 N.Y.",
                        CodeInternal = "00001124",
                        Price = 12000000,
                        Year = 2022,
                        OwnerId = e1.Entity.Id
                    });

                    context.PropertyTrace.Add(new Domain.Realstate.PropertyTrace()
                    {
                        Name = b1.Entity.Name,
                        PropertyId = b1.Entity.Id,
                        Tax = b1.Entity.Price * rand.Next(1, 10) / 1000,
                        DateSale = DateTime.Now.AddMonths(4),
                        Value = b1.Entity.Price - rand.Next(100000, 300000),
                    });

                    context.PropertyTrace.Add(new Domain.Realstate.PropertyTrace()
                    {
                        Name = b1.Entity.Name,
                        PropertyId = b1.Entity.Id,
                        Tax = b1.Entity.Price * rand.Next(1, 10) / 1000,
                        DateSale = DateTime.Now.AddMonths(4),
                        Value = b1.Entity.Price - rand.Next(100000, 300000),
                    });
                    context.PropertyTrace.Add(new Domain.Realstate.PropertyTrace()
                    {
                        Name = b2.Entity.Name,
                        PropertyId = b2.Entity.Id,
                        Tax = b2.Entity.Price * rand.Next(1, 10) / 1000,
                        DateSale = DateTime.Now.AddMonths(8),
                        Value = b2.Entity.Price - rand.Next(100000, 300000),
                    });
                    context.PropertyTrace.Add(new Domain.Realstate.PropertyTrace()
                    {
                        Name = b3.Entity.Name,
                        PropertyId = b3.Entity.Id,
                        Tax = b3.Entity.Price * rand.Next(1, 10) / 1000,
                        DateSale = DateTime.Now.AddMonths(1),
                        Value = b3.Entity.Price - rand.Next(100000, 300000),
                    });
                    context.PropertyTrace.Add(new Domain.Realstate.PropertyTrace()
                    {
                        Name = b4.Entity.Name,
                        PropertyId = b4.Entity.Id,
                        Tax = b4.Entity.Price * rand.Next(1, 10) / 1000,
                        DateSale = DateTime.Now.AddMonths(12),
                        Value = b4.Entity.Price - rand.Next(100000, 300000),
                    });
                    context.PropertyTrace.Add(new Domain.Realstate.PropertyTrace()
                    {
                        Name = b5.Entity.Name,
                        PropertyId = b5.Entity.Id,
                        Tax = b5.Entity.Price * rand.Next(1, 10) / 1000,
                        DateSale = DateTime.Now.AddMonths(19),
                        Value = b5.Entity.Price - rand.Next(100000, 300000),
                    });
                    context.PropertyTrace.Add(new Domain.Realstate.PropertyTrace()
                    {
                        Name = b6.Entity.Name,
                        PropertyId = b6.Entity.Id,
                        Tax = b6.Entity.Price * rand.Next(1, 10) / 1000,
                        DateSale = DateTime.Now.AddMonths(4),
                        Value = b6.Entity.Price - rand.Next(100000, 300000),
                    });

                    context.PropertyTrace.Add(new Domain.Realstate.PropertyTrace()
                    {
                        Name = b7.Entity.Name,
                        PropertyId = b7.Entity.Id,
                        Tax = b7.Entity.Price * rand.Next(1, 10) / 1000,
                        DateSale = DateTime.Now.AddMonths(4),
                        Value = b7.Entity.Price - rand.Next(100000, 300000),
                    });

                    context.PropertyImage.Add(new Domain.Realstate.PropertyImage()
                    {
                        Enabled = true,
                        File = Path.Combine("Images/", "Building01.jpg"),
                        Order = 0,
                        PropertyId = b1.Entity.Id
                    });


                    context.PropertyImage.Add(new Domain.Realstate.PropertyImage()
                    {
                        Enabled = true,
                        File = Path.Combine("Images/", "Building02.jpg"),
                        Order = 0,
                        PropertyId = b2.Entity.Id
                    });

                    context.PropertyImage.Add(new Domain.Realstate.PropertyImage()
                    {
                        Enabled = true,
                        File = Path.Combine("Images/", "Building03.jpg"),
                        Order = 0,
                        PropertyId = b3.Entity.Id
                    });

                    context.PropertyImage.Add(new Domain.Realstate.PropertyImage()
                    {
                        Enabled = true,
                        File = Path.Combine("Images/", "Building04.jpg"),
                        Order = 0,
                        PropertyId = b4.Entity.Id
                    });

                    context.PropertyImage.Add(new Domain.Realstate.PropertyImage()
                    {
                        Enabled = true,
                        File = Path.Combine("Images/", "Building05.jpg"),
                        Order = 0,
                        PropertyId = b5.Entity.Id
                    });

                    context.PropertyImage.Add(new Domain.Realstate.PropertyImage()
                    {
                        Enabled = true,
                        File = Path.Combine("Images/", "Building06.jpg"),
                        Order = 0,
                        PropertyId = b6.Entity.Id
                    });

                    context.PropertyImage.Add(new Domain.Realstate.PropertyImage()
                    {
                        Enabled = true,
                        File = Path.Combine("Images/", "Building07.jpg"),
                        Order = 0,
                        PropertyId = b7.Entity.Id
                    });

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Migration error: " + ex, ex);
            }
        }
    }
}
