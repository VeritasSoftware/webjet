import { Injectable } from '@angular/core';
import { Movie } from '../models/models';

export interface IMoviesService {
    getCheapestMovies(title: string) : Array<Movie>;
}

@Injectable()
export class MoviesService implements IMoviesService {
    
    getCheapestMovies(title: string) : Array<Movie> {
        return null;
    }
}