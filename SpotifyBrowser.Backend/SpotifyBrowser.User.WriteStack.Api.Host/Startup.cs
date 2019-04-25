using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SpotifyBrowser.Application.Shared.Auth;
using SpotifyBrowser.Cqrs.Contracts;
using SpotifyBrowser.Cqrs.Implementation.AspnetCore;
using SpotifyBrowser.Host.ErrorHandling;
using SpotifyBrowser.User.Shared.Identity.Storage;
using SpotifyBrowser.User.WriteStack.Application;
using SpotifyBrowser.User.WriteStack.Domain.Accounts;
using SpotifyBrowser.User.WriteStack.Domain.Implementation;
using SpotifyBrowser.User.WriteStack.Domain.UserManagement;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Reflection;

namespace SpotifyBrowser.User.WriteStack.Api.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {



            services.AddHttpContextAccessor();
            services.AddCqrs(typeof(WriteStackReference).GetTypeInfo().Assembly);

            services.AddScoped<IUser, UserInSession>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<UserProfileRepository>();
            services.AddScoped<IdentityUserManagerFacade>();

            services.AddDbContext<SpotifyBrowserAccountsDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SpotifyBrowserDbContext")));

            services.AddDbContext<SpotifyBrowserIdentityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SpotifyBrowserDbContext")));

            services.AddScoped( provider =>  new UserStore<ApplicationUser>( provider.GetService<SpotifyBrowserIdentityDbContext>()));
            services.AddScoped( provider => new UserManager<ApplicationUser>( provider.GetService<UserStore<ApplicationUser>>(), null, 
                                new PasswordHasher<ApplicationUser>(),
                                new List<UserValidator<ApplicationUser>> { new UserValidator<ApplicationUser>() },
                                new List<PasswordValidator<ApplicationUser>> { new PasswordValidator<ApplicationUser>() },
                                null, new IdentityErrorDescriber() , provider,
                                provider.GetService<ILogger<UserManager<ApplicationUser>>>()));


            services.AddHealthChecks()
                .AddSqlServer(Configuration.GetConnectionString("SpotifyBrowserDbContext"));

            services.AddCors(options =>
            {
                options.AddPolicy("AllRequests", builder =>
                {
                    builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                        .AllowCredentials();
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = Configuration.GetValue<string>("IdProviderSettings:Authority");
                    options.RequireHttpsMetadata = false;
                    options.Audience = Constants.SpotifyBrowserWriteUsersApiName;
                });

            services.AddAutoMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Spotify browser User Management API V1", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseHealthChecks("/HealthCheckStatus");

            app.ConfigureExceptionHandler(loggerFactory.CreateLogger("Global Error Handing"));

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Spotify browser User Management API V1");
            });

            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllRequests");
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
