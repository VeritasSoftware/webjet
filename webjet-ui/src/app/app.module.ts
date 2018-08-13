import { BrowserModule } from '@angular/platform-browser';
//import { CommonModule } from '@angular/common'
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { appRoutes } from './routerConfig';

import { MoviesService } from './services/movies-service';
import { HomeComponent } from './components/home/home.component'

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,    
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [MoviesService],
  bootstrap: [AppComponent, HomeComponent]
})
export class AppModule { }
