import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './components/about/about.component';
import { FeaturedComponent } from './components/featured/featured.component';
import { HomeComponent } from './components/home/home.component';
import { PlaylistsComponent } from './components/playlists/playlists.component';
import { VideosComponent } from './components/videos/videos.component';

const routes: Routes = [
  {
    path: ":name",
    component: HomeComponent,
    children: [
      {
        path: "",
        component: FeaturedComponent
      },
      {
        path: "featured",
        component: FeaturedComponent
      },
      {
        path: "videos",
        component: VideosComponent
      },
      {
        path: "playlists",
        component: PlaylistsComponent
      },
      {
        path: "about",
        component: AboutComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ChannelRoutingModule { }
