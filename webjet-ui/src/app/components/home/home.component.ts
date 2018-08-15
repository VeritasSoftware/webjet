import { Component, OnInit } from '@angular/core';

import { MoviesService } from '../../services/movies-service'
import { ProviderMovie } from '../../models/models';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  movies: Array<ProviderMovie> = new Array<ProviderMovie>();
  title: string = "Cheapest deal on movies!";
  movieTitle: string;
  isInitialLoad: boolean = false;

  constructor(private moviesService: MoviesService) { }

  async ngOnInit() {
    this.isInitialLoad = true;
  }

  async getCheapestDeal() {
    if (this.movieTitle == null || this.movieTitle.length <= 0){
      alert('Please enter a keyword in the movie title.');
      return;
    }
 
    try {      
      this.movies= await this.moviesService.getCheapestDeal(this.movieTitle);
      this.isInitialLoad = false;
    }
    catch(e) {
      alert("Error: " + e.message)
    }    
  }
}
