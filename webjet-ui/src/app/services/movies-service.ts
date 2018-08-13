import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Movie, MovieBase, MovieSource } from '../models/models';

export interface IMoviesService {
    getCheapestMovies(title: string) : Array<Movie>;
    getMovies(source: MovieSource) : Promise<Array<MovieBase>>;
}

@Injectable()
export class MoviesService implements IMoviesService {
    sourceUrl: string = "http://webjetapitest.azurewebsites.net/api/{0}/";

    constructor(private httpClient: HttpClient) {

    }
    
    getCheapestMovies(title: string) : Array<Movie> {
        return null;
    }

    async getMovies(source: MovieSource) : Promise<Array<MovieBase>> {
        var url = this.sourceUrl.replace("{0}", "filmworld");

        debugger;

        // let headers = new HttpHeaders();
        // headers.append('x-access-token','sjd1HfkjU83ksdsm3802k');

        const httpOptions = {
            headers: new HttpHeaders({
              'Access-Control-Allow-Origin': '*',
              'x-access-token': 'sjd1HfkjU83ksdsm3802k'
            })
          };

        return await this.httpClient.get<Array<MovieBase>>(url + "movies", httpOptions)
                         .toPromise();
    }
}