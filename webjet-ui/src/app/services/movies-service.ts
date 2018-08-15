import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { ProviderMovie } from '../models/models';

export interface IMoviesService {
    getCheapestDeal(title: string) : Promise<Array<ProviderMovie>>;
}

@Injectable()
export class MoviesService implements IMoviesService {
    apiUrl: string = "http://localhost:59039/api/";

    constructor(private httpClient: HttpClient) {

    }
    
    async getCheapestDeal(title: string) : Promise<Array<ProviderMovie>> {
        var url = this.apiUrl + "movies/cheapest/" + encodeURIComponent(title);      

        return await this.httpClient.get<Array<ProviderMovie>>(url)
                         .toPromise();
    }    
}