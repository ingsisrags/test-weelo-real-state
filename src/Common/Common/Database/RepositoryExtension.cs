using Common.Utilities.Implements.Repository;
using Common.Utilities.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utilities.Database
{
    public static class RepositoryExtension
    {
        public static void UseRepository(this IServiceCollection services, Type dbContextType)
        {
            services.AddScoped(typeof(DbContext), dbContextType);
            services.AddScoped(typeof(IUnitOfWorkAsync), typeof(UnitOfWork));
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(Repository<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
