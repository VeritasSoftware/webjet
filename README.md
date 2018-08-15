# Webjet tech test

The app has a **micro service based architecture**.

The 2 components of the web system are:

*	.Net Core 2.0 Web API - micro service
*	Angular 6 CLI web app

# Web API

*	Uses built-in dependency injection container.
*	Uses **Newtonsoft.Json** for json serialization.
*	Uses built-in **IMemoryCache** for caching.
*	uses **HttpClient** to make calls to Providers.

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