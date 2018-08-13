export class MovieBase {
    ID: string;
    Title: string;
    Year: string;
    Poster: string;
}

export class Movie extends MovieBase {    
    Rated: string;
    Released: string;
    Genre: string;
    Director: string;
    Actors: string;
    Plot: string;
    Language: string;
    Country: string;
    Price: string;
}

export enum MovieSource {
    cinemaworld,
    filmworld
}