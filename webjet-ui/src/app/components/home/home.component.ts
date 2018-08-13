import { Component, OnInit } from '@angular/core';

import { MoviesService } from '../../services/movies-service'
import { MovieSource, MovieBase } from '../../models/models';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  movies: Array<MovieBase>;

  constructor(private moviesService: MoviesService) { }

  async ngOnInit() {
    this.movies= await this.moviesService.getMovies(MovieSource.cinemaworld)
  }

}
