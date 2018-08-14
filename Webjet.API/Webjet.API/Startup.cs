using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            //Set up dependency injection
            services.AddScoped<IMovieProviderClient<MoviesCollection>>(p => new MovieProviderClient<MoviesCollection>("sjd1HfkjU83ksdsm3802k"))
                    .AddScoped<IMovieProviderClient<MovieDetails>>(p => new MovieProviderClient<MovieDetails>("sjd1HfkjU83ksdsm3802k"))
                    .AddScoped(p => new List<IMovieProvider>()
                                        {
                                            new CinemaWorldProvider(
                                                                        "http://webjetapitest.azurewebsites.net/api/cinemaworld/", 
                                                                        p.GetService<IMovieProviderClient<MoviesCollection>>(),
                                                                        p.GetService<IMovieProviderClient<MovieDetails>>()
                                                                    ),
                                            new FilmWorldProvider(
                                                                    "http://webjetapitest.azurewebsites.net/api/filmworld/", 
                                                                    p.GetService<IMovieProviderClient<MoviesCollection>>(),
                                                                    p.GetService<IMovieProviderClient<MovieDetails>>()
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
