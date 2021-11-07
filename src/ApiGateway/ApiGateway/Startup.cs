using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ApiGateway
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
            services.AddControllersWithViews();

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });


            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

            var identityUrl = Configuration.GetValue<string>("urls:identity");
            var validIssuers = Configuration.GetSection("ValidIssuers").Get<string[]>();
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            .AddIdentityServerAuthentication("IdentityApiKey", options =>
            {
                options.Authority = identityUrl;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters.RequireAudience = false;
                options.TokenValidationParameters.ValidateAudience = false;
                options.TokenValidationParameters.ValidIssuers = validIssuers;
            }, null);

            IdentityModelEventSource.ShowPII = true;

            var origins = Configuration.GetSection("origins").Get<string[]>();
            services.AddCors(options =>
                options.AddPolicy("CorsPolicy", p =>
                            p.WithOrigins(origins)
                                .AllowCredentials()
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                        )
                );

            services.AddOcelot();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("CorsPolicy");

            var forwardOptions = new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
                RequireHeaderSymmetry = false
            };

            forwardOptions.KnownNetworks.Clear();
            forwardOptions.KnownProxies.Clear();
            app.UseForwardedHeaders(forwardOptions);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Use(async (context, next) => { context.Response.Headers.Add("X-Permitted-Cross-Domain-Policies", "none"); await next(); });
            //Security Headers
            //app.UseXXssProtection(options => options.EnabledWithBlockMode());
            //app.UseXContentTypeOptions();
            //app.UseXfo(options => options.SameOrigin());
            //app.UseNoCacheHttpHeaders();
            ////app.UseXDownloadOptions();
            //app.UseRedirectValidation();
            //app.UseXRobotsTag(options => options.NoIndex().NoFollow());
            //app.UseReferrerPolicy(opts => opts.NoReferrerWhenDowngrade());
            //app.UseCsp(options => options
            //    .DefaultSources(s => s.Enabled = false)
            //    //.DefaultSources(s => s.Self())
            //    .BlockAllMixedContent()
            //    .UpgradeInsecureRequests()
            //    .StyleSources(s => s.Self().UnsafeInlineSrc = true)
            //    //.StyleSources(s => s.Self())
            //    .FontSources(s => s.Self())
            //    .FrameAncestors(s => s.Self())
            //    .ImageSources(s => s.Enabled = false)
            //    //.ImageSources(s => s.Self())
            //    .ScriptSources(s => { s.Self().UnsafeInlineSrc = true; })
            ////.ScriptSources(s => { s.Self(); })
            //);
            if (env.IsProduction() || env.IsStaging()) { app.UseHsts(); }


            app.UseOcelot().Wait();
        }
    }
}
