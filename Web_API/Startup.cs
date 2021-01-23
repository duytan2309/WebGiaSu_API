using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Lib.Data.Entities;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Lib.Domain.EF;
using Lib.Domain.Extensions.Interfaces;
using Lib.Domain.Proceduce.Interfaces;
using Lib.Domain.Proceduce.Repositories;
using Lib.Domain.EF.Interfaces;

namespace Web_API
{
    public class Startup
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

        public Startup(IConfiguration configuration, IHostingEnvironment env)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            Configuration = configuration;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<ConnectionStrings>(Configuration.GetSection("DbConnection"));
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed
                // for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;

            });
            services.AddDbContext<AppDbContext>(options =>
                  options.UseMySQL(Configuration.GetConnectionString("DbConnection")
             ,
               o =>
             {
                 o.MigrationsAssembly("Data");
             }

             ));

            services.AddIdentity<AppUser, AppRole>(config =>
            {
                config.SignIn.RequireConfirmedEmail = true;

            })
              //.AddEntityFrameworkStores<AppDbContext>()
              .AddDefaultTokenProviders()
              .AddRoleManager<RoleManager<AppRole>>()
              .AddUserManager<UserManager<AppUser>>()
              ;


            services.AddTransient<UserManager<AppUser>>();
            services.AddTransient<RoleManager<AppRole>>();
            #region Connecstrings ProdureStores 
            services.AddTransient<RequestDelegate>();
            services.AddTransient<ITestInterface, TestRepository>();
            services.AddTransient<IDapper, Lib.Domain.EF.Dapper>();
            #endregion Connecstrings ProdureStores

            #region Google, FaceBook

            services.AddAuthentication()
            //.AddFacebook(facebookOpts =>
            //{
            //    IConfigurationSection googleAuthNSection =
            //        Configuration.GetSection("Authentication:Facebook");
            //    facebookOpts.AppId = Configuration["Authentication:Facebook:AppId"];
            //    facebookOpts.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            //})
            //.AddGoogle(googleOpts =>
            //{
            //    IConfigurationSection googleAuthNSection =
            //        Configuration.GetSection("Authentication:Google");
            //    googleOpts.ClientId = Configuration["Authentication:Google:ClientId"];
            //    googleOpts.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
            //})
            ;

            #endregion Google, FaceBook

            services.AddRouting();
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/spboyer"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });

            try
            {
                var key = Encoding.ASCII.GetBytes(Configuration["JWT:key"]);

                //Tạo Token
                var tokenParams = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = Configuration["JWT:issuer"],
                    ValidAudience = Configuration["JWT:audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                //Add JWT Authentication
                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(jwtconfig =>
                {
                    jwtconfig.TokenValidationParameters = tokenParams;
                });

                //services.Configure<KestrelServerOptions>(
                //            Configuration.GetSection("Kestrel"));

                services.AddCors(
                    options =>
                {
                    options.AddDefaultPolicy(
                        builder =>
                        {
                            builder.WithOrigins("http://example.com",
                                                "http://www.contoso.com");
                        });

                    options.AddPolicy("AnotherPolicy",
                        builder =>
                        {
                            builder.WithOrigins("http://www.contoso.com")
                                                .AllowAnyHeader()
                                                .AllowAnyMethod();
                        }

                        );
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseCors("AllowAllOrigins");
            app.UseHttpsRedirection();

            app.UseCookiePolicy();

            SymmetricSecurityKey SigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JWT:key"]));//line 2

            //app.UseMiddleware<TokenProviderMiddleware>(new TokenProviderOptions()
            //{
            //    SigningCredentials = new SigningCredentials(SigningKey, SecurityAlgorithms.HmacSha256),
            //});

            app.UseAuthentication();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger
            // JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseSignalR(hubs =>
            {
                hubs.MapHub<ChatHub>("/chathub");
            });


            app.UseMvc();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                     name: "area",
                     template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}