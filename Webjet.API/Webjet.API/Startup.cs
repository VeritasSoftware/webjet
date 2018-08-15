using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using Webjet.Entities;
using Webjet.Repository;
using Webjet.Repository.Clients;
using Webjet.Repository.Providers;

namespace Webjet.API
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
            //Get settings from appSettings
            Settings settings = new Settings();
            this.Configuration.GetSection("Settings").Bind(settings);

            var token = settings.Token;
            var noOfRetries = settings.NoOfRetries;
            var cacheDurationInHours = settings.CacheDurationInHours;
            var cinemaWorldUrl = settings.BaseProviderUrl + settings.Providers[Entities.Provider.cinemaworld].Url;
            var filmWorldUrl = settings.BaseProviderUrl + settings.Providers[Entities.Provider.filmworld].Url;

            //Add memory cache
            services.AddMemoryCache();

            //Set up dependency injection
            services.AddScoped<IMovieProviderClient>(p => new MovieProviderClient(token, noOfRetries))
                    .AddScoped<ICacheProvider>(p => new CacheProvider(p.GetService<IMemoryCache>(), cacheDurationInHours))
                    .AddScoped(p => new List<IMovieProvider>()
                                        {
                                            new CinemaWorldProvider(
                                                                        cinemaWorldUrl, 
                                                                        p.GetService<IMovieProviderClient>(),
                                                                        p.GetService<ICacheProvider>()
                                                                    ),
                                            new FilmWorldProvider(
                                                                    filmWorldUrl, 
                                                                    p.GetService<IMovieProviderClient>(),
                                                                    p.GetService<ICacheProvider>()
                                                                 )
                                        }
                              )
                    .AddScoped<IMovieRepository, MovieRepository>();

            services.BuildServiceProvider();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
