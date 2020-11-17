using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using NWSocial.Data;
using NWSocial.Models;

namespace NWSocial
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
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
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<NWSContext>()  
                .AddDefaultTokenProviders();  
            services.AddScoped<RoleManager<Role>>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.LoginPath = "/account/google-login";
            })
            .AddGoogle(options =>
            {
                IConfigurationSection googleAuthNSection = Configuration.GetSection("Authentication:Google");
                options.ClientId = "849948674332-1t1q6vl9qp06h8k2cjv20leup1j1v6go.apps.googleusercontent.com";
                options.ClientSecret = "ZL3AZ7QtsBoK-jOUqkMdaZcy";
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api doc", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseSwagger();

            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1");
                s.RoutePrefix = string.Empty;
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            PrepDB.PrepDb(app);
        }
    }
}
