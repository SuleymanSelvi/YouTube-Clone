import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { HeaderComponent } from './components/header/header.component';
import { WatchComponent } from './components/watch/watch.component';
import { VideoCommentsComponent } from './components/video-comments/video-comments.component';
import { LoginComponent } from './components/login/login.component';
import { RegistirComponent } from './components/registir/registir.component';
import { ResultsComponent } from './components/results/results.component';
import { SidebarsComponent } from './components/sidebars/sidebars.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    WatchComponent,
    VideoCommentsComponent,
    LoginComponent,
    RegistirComponent,
    ResultsComponent,
    SidebarsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
