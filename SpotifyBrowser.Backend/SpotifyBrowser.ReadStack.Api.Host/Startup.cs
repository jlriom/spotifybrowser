using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SpotifyApi.Facade.Contracts;
using SpotifyApi.Facade.Implementation.Auth;
using SpotifyApi.Facade.Implementation.Services;
using SpotifyBrowser.Application.Shared.Auth;
using SpotifyBrowser.Cqrs.Contracts;
using SpotifyBrowser.Cqrs.Implementation.AspnetCore;
using SpotifyBrowser.Host.ErrorHandling;
using SpotifyBrowser.ReadStack.Api.Host.Music;
using SpotifyBrowser.ReadStack.Aplication;
using SpotifyBrowser.ReadStack.Aplication.MyMusic.Services;
using SpotifyBrowser.ReadStack.DataAccess.Contracts.Album;
using SpotifyBrowser.ReadStack.DataAccess.Contracts.Artist;
using SpotifyBrowser.ReadStack.DataAccess.Implementation;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;

namespace SpotifyBrowser.ReadStack.Api.Host
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
            services.AddOptions();
            services.Configure<SpotifyClientCredentialsSettings>(Configuration.GetSection("SpotifyClientCredentialsSettings"));

            services.AddSingleton(provider =>
            {
                var spotifyClientCredentialsSettings =
                    provider.GetService<IOptions<SpotifyClientCredentialsSettings>>();

                return new ClientCredentialsSettings(spotifyClientCredentialsSettings.Value.ClientSecret,
                    spotifyClientCredentialsSettings.Value.ClientId);
            });

            services.AddHttpContextAccessor();

            services.AddScoped<IUser, UserInSession>();
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<ITrackService, TrackService>();
            services.AddScoped<IPlaylistService, PlaylistService>();

            services.AddScoped<IMyAlbumsReadOnlyService, MyAlbumsReadOnlyService>();
            services.AddScoped<IMyArtistsReadOnlyService, MyArtistsReadOnlyService>();

            services.AddScoped<IAlbumTagsReadOnlyRepository, AlbumTagsReadOnlyRepository>();
            services.AddScoped<IArtistTagsReadOnlyRepository, ArtistTagsReadOnlyRepository>();

            services.AddCqrs(typeof(ReadStackReference).GetTypeInfo().Assembly);

            services.AddDbContext<SpotifyBrowserReadOnlyDbContext>(options =>
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
                    options.Audience = Constants.SpotifyBrowserReadApiName;
                });

            services.AddAutoMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Spotify browser read stack API V1", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseHealthChecks("/HealthCheckStatus");

            app.ConfigureExceptionHandler(loggerFactory.CreateLogger("Global Error Handing"));

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Spotify browser read stack API V1");
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
