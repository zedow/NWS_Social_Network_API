using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NWSocial.Data;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace NWSocial
{
    public class Startup
    {
        //private string _moviesApiKey = null; // secretKey step 1
        //private string _connection = null;   // login secretKey step 2
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { 
            /*_moviesApiKey = Configuration["Movies:ServiceApiKey"];  //login stp 1 secretKey

            var moviesConfig = Configuration.GetSection("Movies")
                                .Get<MovieSettings>();
            _moviesApiKey = moviesConfig.ServiceApiKey;*/


            /*var builder = new SqlConnectionStringBuilder(           //login step 2 secretKey
            Configuration.GetConnectionString("Movies"));
            builder.Password = Configuration["DbPassword"];
            _connection = builder.ConnectionString;*/


            // ConnectionString établi dans le fichier appsettings.json
            services.AddDbContext<NWSContext>(opt =>
            {

                opt.UseMySql(Configuration.GetConnectionString("NWSConnection"), builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            });
            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<INWSRepo, SqlNWSRepo>();
                
                   /*
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();*/


            //Authentification google
            services.AddAuthentication() 
             .AddGoogle(options =>
             {
                IConfigurationSection googleAuthNSection =
                    Configuration.GetSection("Authentication:Google");

                options.ClientId = googleAuthNSection["ClientId"];
                options.ClientSecret = googleAuthNSection["ClientSecret"];
             });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
             app.Run(async (context) =>
             {
                 /*var result = string.IsNullOrEmpty(_moviesApiKey) ? "Null" : "Not Null";  //login step 1 secretKey
                 await context.Response.WriteAsync($"Secret is {result}");*/
                 await context.Response.WriteAsync($"DB Connection: {_connection}");        //login step 2 secretKey
             });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
