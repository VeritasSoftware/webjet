export class Movie {
    id: string;
    title: string;
    year: string;
    poster: string;
}

export class MovieDetails extends Movie {    
    rated: string;
    released: string;
    genre: string;
    director: string;
    actors: string;
    plot: string;
    language: string;
    country: string;
    price: string;
}

export class ProviderMovie {
    provider: string;
    movie: MovieDetails
}