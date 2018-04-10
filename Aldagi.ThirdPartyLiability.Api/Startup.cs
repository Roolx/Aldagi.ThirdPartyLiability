using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aldagi.ThirdPartyLiability.BLL.Abstract;
using Aldagi.ThirdPartyLiability.BLL.Concrete;
using Aldagi.ThirdPartyLiability.DAL;
using Aldagi.ThirdPartyLiability.DAL.Abstract;
using Aldagi.ThirdPartyLiability.DAL.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Aldagi.ThirdPartyLiability.Api
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
            services.AddCors(options =>
            {
                options.AddPolicy("all",
                    policy =>
                    policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin());
            });

            services.AddMvc();

            services.AddAuthentication("Bearer")
               .AddIdentityServerAuthentication(options =>
               {
                   options.Authority = "http://localhost:5000";
                   options.RequireHttpsMetadata = false;
                   options.ApiName = "tplApi";
               });

            //DAL services
            services.AddScoped<ICarDAL, CarDAL>();
            services.AddScoped<IThirdPartyLiabilityDAL, ThirdPartyLiabilityDAL>();
            services.AddScoped<IClientDAL, ClientDAL>();

            //BLL Services
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IThirdPartyLiabilityService, ThirdPartyLiabilityService>();
            services.AddScoped<IClientService, ClientService>();

            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LocalDatabase")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = Configuration.GetValue<string>("ApiName"), Version = Configuration.GetValue<string>("ApiVersion") });
                c.AddSecurityDefinition("oauth2", new OAuth2Scheme()
                {
                    Flow = "password",
                    TokenUrl = "http://localhost:5000/connect/token",
                    AuthorizationUrl = "http://localhost:5000/connect/token",
                    Scopes = new Dictionary<string, string>
                        {
                            { "tplApi", "Access read operations" }
                        }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

                c.OAuthAdditionalQueryStringParams(new { client_id = "dsf", client_secret = "2BB80D537B1DA3E38BD30361AA855686BDE0EACD7162FEF6A25FE97BF527A25B" });

            });
            app.UseCors("all");
            app.UseMvc();
        }
    }
}
