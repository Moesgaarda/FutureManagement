using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace API
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
            // TODO skal refactors til ikke at tillade svage passwords på sigt, se udemy lecture 198.
            IdentityBuilder builder = services.AddIdentityCore<User>(opt => {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 4;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
            });

            /* Used for setting up Identity Core */
            builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
            builder.AddEntityFrameworkStores<DataContext>();
            builder.AddRoleValidator<RoleValidator<Role>>();
            builder.AddRoleManager<RoleManager<Role>>();
            builder.AddSignInManager<SignInManager<User>>();

            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value);

            services.AddDbContext<DataContext>(x => x.UseMySql(Configuration.GetConnectionString("SqlConn")));
            services.AddSingleton<IFileProvider>(  
            new PhysicalFileProvider(  
                Path.Combine(Directory.GetCurrentDirectory())));

            /* Every user needs to be authenticated before it can access API */
            services.AddMvc(options => {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            })
                    .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddCors();
            services.AddAutoMapper();
            services.AddScoped<IEventLogRepository, EventLogRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemTemplateRepository, ItemTemplateRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IFileInputRepository, FileInputRepository>();
            services.AddScoped<IUnitTypeRepository, UnitTypeRepository>();
            services.AddScoped<ITemplateCategoryRepository, TemplateCategoryRepository>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            /* This part defines the roles, which are used to define which pages are used. 
            *  It should be in the format:
            *  - AddPolicy & RequireRole = PartOfSystem_Subpart */

            services.AddAuthorization(options => {
                options.AddPolicy("ItemTemplates_Add", policy => policy.RequireRole("ItemTemplates_Add"));
                options.AddPolicy("ItemTemplates_View", policy => policy.RequireRole("ItemTemplates_View"));
                options.AddPolicy("ItemTemplates_ActivateDeactivate", policy => policy.RequireRole("ItemTemplates_ActivateDeactivate"));
                options.AddPolicy("Calender_Add", policy => policy.RequireRole("Calender_Add"));
                options.AddPolicy("Calender_View", policy => policy.RequireRole("Calender_View"));
                options.AddPolicy("Customer_Add", policy => policy.RequireRole("Customer_Add"));
                options.AddPolicy("Customer_View", policy => policy.RequireRole("Customer_View"));
                options.AddPolicy("Customer_Edit", policy => policy.RequireRole("Customer_Edit"));
                options.AddPolicy("Customer_ActivateDeactivate", policy => policy.RequireRole("Customer_ActivateDeactivate"));
                options.AddPolicy("EventLogs_View", policy => policy.RequireRole("EventLogs_View"));
                options.AddPolicy("Upload_Files", policy => policy.RequireRole("Upload_Files"));
                options.AddPolicy("Download_Files", policy => policy.RequireRole("Download_Files"));
                options.AddPolicy("Items_Add", policy => policy.RequireRole("Items_Add"));
                options.AddPolicy("Items_View", policy => policy.RequireRole("Items_View"));
                options.AddPolicy("Items_Edit", policy => policy.RequireRole("Items_Edit"));
                options.AddPolicy("Items_ActivateDeactivate", policy => policy.RequireRole("Items_ActivateDeactivate"));
                options.AddPolicy("Items_Delete", policy => policy.RequireRole("Items_Delete"));
                options.AddPolicy("Order_View", policy => policy.RequireRole("Order_View"));
                options.AddPolicy("Order_Add", policy => policy.RequireRole("Order_Add"));
                options.AddPolicy("Order_Edit", policy => policy.RequireRole("Order_Edit"));
                options.AddPolicy("Order_Delete", policy => policy.RequireRole("Order_Delete"));
                options.AddPolicy("Order_ActivateDeactivate", policy => policy.RequireRole("Order_ActivateDeactivate"));
                options.AddPolicy("Project_View", policy => policy.RequireRole("Project_View"));
                options.AddPolicy("Project_Add", policy => policy.RequireRole("Project_Add"));
                options.AddPolicy("Project_Edit", policy => policy.RequireRole("Project_Edit"));
                options.AddPolicy("Project_Delete", policy => policy.RequireRole("Project_Delete"));
                options.AddPolicy("User_Add", policy => policy.RequireRole("User_Add"));
                options.AddPolicy("User_View", policy => policy.RequireRole("User_View"));
                options.AddPolicy("User_Edit", policy => policy.RequireRole("User_Edit"));
                options.AddPolicy("User_Delete", policy => policy.RequireRole("User_Delete"));
                options.AddPolicy("User_ActivateDeactivate", policy => policy.RequireRole("User_ActivateDeactivate"));
                options.AddPolicy("UnitTypes_View", policy => policy.RequireRole("UnitTypes_View"));
                options.AddPolicy("UnitTypes_Add", policy => policy.RequireRole("UnitTypes_Add"));
                options.AddPolicy("Categories_View", policy => policy.RequireRole("Categories_View"));
                options.AddPolicy("Categories_Add", policy => policy.RequireRole("Categories_Add"));
                
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Global exceptionhandler if not in Dev environment
                app.UseExceptionHandler(builder => {
                    builder.Run(async context => {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if(error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });
            }
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseAuthentication();
            app.UseMvc(routes =>
                routes.MapSpaFallbackRoute(
                name: "spa-fallback",
                defaults: new { controller = "Fallback", action = "Index" }
                )
                );
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
