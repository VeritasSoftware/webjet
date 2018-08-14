using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
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
            services.AddMemoryCache();

            //Set up dependency injection
            services.AddScoped<IMovieProviderClient>(p => new MovieProviderClient("sjd1HfkjU83ksdsm3802k"))
                    .AddScoped<ICacheProvider>(p => new CacheProvider(p.GetService<IMemoryCache>(), 10))
                    .AddScoped(p => new List<IMovieProvider>()
                                        {
                                            new CinemaWorldProvider(
                                                                        "http://webjetapitest.azurewebsites.net/api/cinemaworld/", 
                                                                        p.GetService<IMovieProviderClient>(),
                                                                        p.GetService<ICacheProvider>()
                                                                    ),
                                            new FilmWorldProvider(
                                                                    "http://webjetapitest.azurewebsites.net/api/filmworld/", 
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
