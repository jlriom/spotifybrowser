using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SpotifyBrowser.Cqrs.Contracts;
using SpotifyBrowser.Cqrs.Implementation.AspnetCore;
using SpotifyBrowser.Domain;
using SpotifyBrowser.Host.ErrorHandling;
using SpotifyBrowser.WriteStack.Application;
using SpotifyBrowser.WriteStack.Domain;
using SpotifyBrowser.WriteStack.Domain.Implementation;
using SpotifyBrowser.WriteStack.Domain.MyAlbums;
using SpotifyBrowser.WriteStack.Domain.MyArtists;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using SpotifyBrowser.Application.Shared.Auth;

namespace SpotifyBrowser.WriteStack.Api.Host
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

            services.AddScoped<IUser, UserInSession>();

            services.AddScoped<ISpotifyReadOnlyRepository<MyAlbum>, MyAlbumsWriteRepository>();
            services.AddScoped<IRepository<MyAlbum>, MyAlbumsWriteRepository>();

            services.AddScoped<ISpotifyReadOnlyRepository<MyArtist>, MyArtistsWriteRepository>();
            services.AddScoped<IRepository<MyArtist>, MyArtistsWriteRepository>();

            services.AddCqrs(typeof(WriteStackReference).GetTypeInfo().Assembly);

            services.AddDbContext<SpotifyBrowserWriteDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SpotifyBrowserDbContext")));

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
                    options.Audience = Constants.SpotifyBrowserWriteApiName;
                });

            services.AddAutoMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Spotify browser write stack API V1", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseHealthChecks("/HealthCheckStatus");

            app.ConfigureExceptionHandler(loggerFactory.CreateLogger("Global Error Handing"));

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Spotify browser write stack API V1");
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
