import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MoviesService } from '../../services/movies-service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [MoviesService],
  declarations: []
})
export class HomeModule { }
