using System;
using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Product.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            string connectionString = Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTION");
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");
            var migrationsAssembly = "Farming.Persistense.Database";

           // services.AddDbContext<ApplicationDbContext>(options =>
           //    options.UseSqlServer(connectionString,
           //    sqlServerOptionsAction: sqlOptions =>
           //    {
           //        sqlOptions.MigrationsAssembly(migrationsAssembly);
           //        sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
           //    }),
           //    ServiceLifetime.Scoped
           //);


            services.AddAuthorization(options =>
            {

            });

            var profiles = "Farming.Mappers"; //typeof("Company.Mappers").Assembly;

            MapperConfiguration mappingConfig = new MapperConfiguration(config =>
            {
                config.AddMaps(profiles);
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            //utilities
            //services.AddScoped(typeof(IGrowUnitService), typeof(GrowUnitService));
            //services.AddScoped(typeof(IGrowPlanService), typeof(GrowPlanService));
            //services.AddScoped(typeof(IStrainService), typeof(StrainService));
            //services.AddScoped(typeof(ICultivateService), typeof(CultivateService));

            //AddSwagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo() { Title = "Company service", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
            });

            //Add repository
            //services.UseRepository(typeof(ApplicationDbContext));

            //Add Cors
            var origins = Configuration.GetSection("origins").Get<string[]>();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins(origins)
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var pathBase = Configuration["PATH_BASE"] + "/farming/api";
            if (!string.IsNullOrEmpty(pathBase))
            {
                loggerFactory.CreateLogger<Startup>().LogDebug("Using PATH BASE '{pathBase}'", pathBase);
                app.UsePathBase(pathBase);
            }

            // //swagger
            app.UseSwagger(setup =>
            {
                setup.PreSerializeFilters.Add((swagger, httpReq) =>
                {

                });
            })
           .UseSwaggerUI(setup =>
           {
               setup.SwaggerEndpoint($"/swagger/v1/swagger.json", "Auth.API V1");
           });
            //cors
            app.UseCors("CorsPolicy");

            var forwardOptions = new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
                RequireHeaderSymmetry = false
            };

            forwardOptions.KnownNetworks.Clear();
            forwardOptions.KnownProxies.Clear();

            app.UseForwardedHeaders(forwardOptions);



            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });
        }
    }
}
