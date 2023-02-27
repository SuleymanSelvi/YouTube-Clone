import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ServicesService } from 'src/app/services/services.service';

@Component({
  selector: 'app-featured',
  templateUrl: './featured.component.html',
  styleUrls: ['./featured.component.css']
})
export class FeaturedComponent {

  constructor(private services: ServicesService, private route: ActivatedRoute) { }

  channelName: any
  userVideos: any
  popularVideos: any

  ngOnInit(): void {
    this.channelName = this.route.snapshot.paramMap.get('name')

    this.services.getVideoByUserId(this.channelName).subscribe((res: any) => {
      if (res.success) {
        this.userVideos = res.dataList
        this.popularVideos = res.dataList.sort((a: any, b: any) => b.videoView - a.videoView)
      }
    })
  }
}
