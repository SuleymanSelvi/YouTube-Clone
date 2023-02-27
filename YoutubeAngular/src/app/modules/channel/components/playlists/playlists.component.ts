import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ServicesService } from 'src/app/services/services.service';

@Component({
  selector: 'app-playlists',
  templateUrl: './playlists.component.html',
  styleUrls: ['./playlists.component.css']
})
export class PlaylistsComponent {

  constructor(private services: ServicesService, private route: ActivatedRoute) { }

  channelName : any
  playlists : any

  ngOnInit(): void {
    this.channelName = this.route.snapshot.paramMap.get('name')
    this.channelName = "Yırtık Pantolon"

    this.services.getPlaylistsByUserId(this.channelName).subscribe((res: any) => {
      if (res.success) {
        this.playlists = res.dataList
        console.log(res.dataList)
      }
    })
  }
}
