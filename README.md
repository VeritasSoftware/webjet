# Webjet tech test

The web system has a **micro service based architecture**.

The 2 components are:

*	.Net Core 2.0 Web API - micro service
*	Angular 6 CLI Web UI App

# .Net Core 2.0 Web API - micro service

*	Uses built-in **dependency injection** container.
*	Uses **Newtonsoft.Json** for json serialization.
*	Uses built-in **IMemoryCache** for caching.
*	Uses **HttpClient** to make calls to Providers.

## End points:

The API has 1 controller: **Movies Controller**.

| Name | Verb | Uri | Sample |
| --- | --- | --- | --- |
| GetCheapestDeal | GET | api/movies/cheapest/{title} | http://localhost:59039/api/movies/cheapest/Empire |

The API comprises of implementations of below interfaces:

| Interface | Explanation |
| --- | --- |
| **IMovieProviderClient** | For getting data from Providers using HttpClient. |
| **IMovieProvider** | All Providers must implement this interface. CinemaWorld and FilmWorld are the current 2 Providers. |
| **ICacheProvider** | For caching the data returned from the client. Uses built-in **IMemoryCache**. |
| **IMovieRepository** | Contains repository api. Injected into the controller. Currently has the logic for getting the cheapest deal from the data from Providers. |

# Angular 6 CLI Web UI App

![Screenshot](https://github.com/VeritasSoftware/webjet/blob/master/webjet-ui/Screenshot.jpg)

*	Has a service called Movies Service. This calls the API using HttpClient.
*	Has a component to find the cheapest deals on movies.
*	Enter a keyword from the movie title to search for the cheapest deal.