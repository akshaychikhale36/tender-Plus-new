using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using TenderPlus.Api.Authorize;
using TenderPlus.Api.Middleware;
using TenderPlus.Core.Manager;
using TenderPlus.DBInfra.Manager;
using TenderPlus.DBInfra.Models;

namespace TenderPlus.Api
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
            services.AddControllers();

            //services.AddAutoMapper(typeof(Startup));

            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "TenderPlus Api",
                    Description = "A simple example ASP.NET Core Web API",

                    Contact = new OpenApiContact
                    {
                        Name = "Akshay Chikhale",
                        Email = "akshay.chikhale@wipro.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Akshay"
                    }
                });
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMvc()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });
            services.AddDbContext<TenderPlusDBContext>(option => option.UseSqlServer(Configuration.GetConnectionString("TenderPlusConnectionString")));

            services.AddTransient<ILoginCoreManager, LoginCoreManager>();
            services.AddTransient<IUserCoreManager, UserCoreManager>();
            services.AddTransient<ITenderCoreManager, TenderCoreManager>();
            services.AddTransient<IBiddingCoreManager, BiddingCoreManager>();


            services.AddTransient<IUserDBManager, UserDBManager>();
            services.AddTransient<ILoginDBManager, LoginDBManager>();
            services.AddTransient<ITenderDBManager, TenderDBManager>();
            services.AddTransient<IBiddingDBManager, BiddingDBManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMiddleware<JwtMiddleware>();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseCors(x => x
             .AllowAnyMethod()
             .AllowAnyHeader()
             .SetIsOriginAllowed(origin => true) // allow any origin
             .AllowCredentials()); // allow credentials

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
