import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ChannelRoutingModule } from './channel-routing.module';
import { VideosComponent } from './components/videos/videos.component';
import { AboutComponent } from './components/about/about.component';
import { HomeComponent } from './components/home/home.component';
import { HeaderComponent } from './components/header/header.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { FeaturedComponent } from './components/featured/featured.component';
import { PlaylistsComponent } from './components/playlists/playlists.component';


@NgModule({
  declarations: [
    VideosComponent,
    AboutComponent,
    HomeComponent,
    HeaderComponent,
    SidebarComponent,
    FeaturedComponent,
    PlaylistsComponent
  ],
  imports: [
    CommonModule,
    ChannelRoutingModule
  ],
  exports: [
  ]
})
export class ChannelModule { }
