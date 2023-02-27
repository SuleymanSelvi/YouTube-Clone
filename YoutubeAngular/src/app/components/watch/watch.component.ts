import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ServicesService } from 'src/app/services/services.service';

@Component({
  selector: 'app-watch',
  templateUrl: './watch.component.html',
  styleUrls: ['./watch.component.css']
})

export class WatchComponent {

  constructor(private services: ServicesService, private route: ActivatedRoute, private router: Router) { }

  videoDetail: any
  videoList: any
  videoId: any
  session: any
  playlistId: any
  playlistVideos: any

  ngOnInit(): void {
    const session: any = localStorage.getItem("session")
    this.session = JSON.parse(session)

    // AYNI COMPONENT'de ki BAŞKA BİR İÇERİĞE GİTMEK İÇİN
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;

    this.videoId = this.route.snapshot.paramMap.get("id");

    this.route.queryParams.subscribe(queryParams => {
      this.playlistId = queryParams['list'];
    })

    this.getVideoById();
    this.getVideosByPlaylists();
    this.getAllVideos();
    this.videoView();
    this.javaScript();
  }

  id: any
  getVideoById() {

    if (this.session != null) {
      this.id = this.session.id
    }
    else {
      this.id = 0
    }

    this.services.getVideoById(this.videoId, this.id).subscribe((res: any) => {
      if (res.success) {
        this.videoDetail = res.data
      }
    })
  }

  getVideosByPlaylists() {
    this.services.getVideosByPlaylists(this.playlistId).subscribe((res: any) => {
      if (res.success) {
        this.playlistVideos = res.dataList
      }
    })
  }

  getAllVideos() {
    this.services.getAllVideos().subscribe((res: any) => {
      if (res.success) {
        this.videoList = res.dataList
      }
    })
  }

  videoView() {
    if (this.session != null) {
      this.id = this.session.id
    }
    else {
      this.id = 0
    }

    this.services.videoView(this.videoId, this.id).subscribe((res: any) => {
      if (res.success) {
        this.videoDetail.VideoView = res.optionalCount
      }
    })
  }

  videoSaved() {
    if (this.session != null) {
      this.services.videoSaved(this.videoId, this.session.id).subscribe((res: any) => {
        if (res.success) {
          this.videoDetail.isSaved = res.optionalBoolean
        }
      })
    }
    else {
      location.href = "/login"
    }
  }

  subscribers(followedId: any) {

    if (this.session != null) {
      this.services.subscribers(followedId, this.session.id).subscribe((res: any) => {
        if (res.success) {
          this.videoDetail.isSubscribers = res.optionalBoolean
          this.videoDetail.channelSubscribersCount = res.optionalCount
        }
        else {
          alert()
        }
      })
    }
    else {
      location.href = "/login"
    }
  }

  videoLike() {
    if (this.session != null) {
      this.services.videoLike(this.videoId, this.session.id).subscribe((res: any) => {
        if (res.success) {
          this.videoDetail.isLike = res.optionalBoolean
          this.videoDetail.likeCount = res.optionalCount
        }
        else {
          alert()
        }
      })
    }
    else {
      location.href = "/login"
    }
  }

  javaScript() {
    const closeButton = document.getElementById("closeVideoList");
    const list = document.getElementById("list");
    const videoList = document.getElementById("videoList");
    const classes = closeButton?.classList;

    closeButton?.addEventListener('click', () => {
      const result = classes?.toggle("icon-close");
      if (result) {
        (videoList as HTMLElement).style.display = "block";
        (list as HTMLElement).style.height = "21%";
      }
      else {
        (videoList as HTMLElement).style.display = "none";
        (list as HTMLElement).style.height = "6.2%";
      }
    })

    // closeButton?.addEventListener("click", function () {
    //   const value = this.classList.value
    //   if (value == "icon-close") {
    //     this.classList.remove("icon-close");
    //     this.classList.add("icon-arrow-down");

    //     (videoList as HTMLElement).style.display = "none";
    //     (list as HTMLElement).style.height = "6.2%";
    //   }
    //   else {
    //     this.classList.remove("icon-arrow-down");
    //     this.classList.add("icon-close");

    //     (videoList as HTMLElement).style.display = "block";
    //     (list as HTMLElement).style.height = "21%";
    //   }
    // });

  }
}
