import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ServicesService } from 'src/app/services/services.service';
// declare function myfunction(): any;

@Component({
  selector: 'app-videos',
  templateUrl: './videos.component.html',
  styleUrls: ['./videos.component.css']
})
export class VideosComponent {

  constructor(private services: ServicesService, private route: ActivatedRoute) { }

  session: any
  channelName: any
  videoList: any
  
  playlist: boolean = true
  addPlaylistDiv: boolean = false
  playlists: any
  radioValue: any
  selectedVideoId: any

  ngOnInit(): void {
    const session: any = localStorage.getItem("session")
    this.session = JSON.parse(session)

    this.channelName = this.route.snapshot.paramMap.get('name')

    this.services.getVideoByUserId(this.channelName).subscribe((res: any) => {
      if (res.success) {
        this.videoList = res.dataList
      }
    })

    // myfunction();
  }

  openPopup(selectedVideoId: any) {
    this.selectedVideoId = selectedVideoId

    this.services.getPlaylistsByUserId("Yırtık Pantolon").subscribe((res: any) => {
      if (res.success) {
        this.playlists = res.dataList
      }
    })

    const popup = <HTMLElement>document.getElementById('popup');
    popup.style.visibility = "visible"
    popup.style.filter = "opacity(1)"
  }

  closePopup() {
    const popup = document.getElementById('popup') as HTMLInputElement;
    popup.style.visibility = "hidden"
  }

  newPlaylistDiv() {
    this.addPlaylistDiv = !this.addPlaylistDiv
    this.playlist = !this.playlist
  }

  newPlaylist(name: any) {
    if (name.length > 0) {
      this.services.newPlaylist(41, name).subscribe((res: any) => {
        if (res.success) {

          this.services.getPlaylistsByUserId("Yırtık Pantolon").subscribe((res: any) => {
            if (res.success) {
              this.playlists = res.dataList
            }
          })

          this.addPlaylistDiv = false
          this.playlist = true
        }
      })
    }
    else {
      const playlistName = document.getElementById("name") as HTMLElement;
      playlistName.focus();
      playlistName.style.border = "1px solid red"
    }
  }

  onChangeRadio(event: any) {
    this.radioValue = event.target.value
  }

  newPlaylistVideo() {
    if (this.radioValue != null) {
      this.services.newPlaylistVideo(this.session.id, this.selectedVideoId, this.radioValue).subscribe((res: any) => {
        if (res.success) {
          const popup = <HTMLElement>document.getElementById('popup');
          popup.style.visibility = "hidden"
        }
      })
    }
    else {
      const playlist = <HTMLElement>document.getElementById('playlist');
      playlist.style.border = "1px solid red"
    }
  }
}
