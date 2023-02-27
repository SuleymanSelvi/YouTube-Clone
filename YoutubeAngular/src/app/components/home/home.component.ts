import { Component } from '@angular/core';
import { ServicesService } from 'src/app/services/services.service';
import * as $ from 'jquery';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  constructor(private services: ServicesService) { }

  videoList: any
  categoriesList: any

  ngOnInit(): void {
    this.getAllVideos()
    this.getCategories()
  }

  getAllVideos() {
    this.services.getAllVideos().subscribe((res: any) => {
      if (res.success) {
        this.videoList = res.dataList
      }
    })
  }

  getCategories() {
    this.services.getCategories().subscribe((res: any) => {
      if (res.success) {
        this.categoriesList = res.dataList
      }
    })
  }

  getVideoByCategoriesId(id: any) {
    this.services.getVideoByCategoriesId(id).subscribe((res: any) => {
      if (res.success) {
        this.videoList = res.dataList
      }
    })
  }

  vid: any
  playVideo(videoId: any) {
    this.vid = document.getElementById("video" + videoId);
    
    setTimeout(() => {
      this.vid.play()
      this.vid.controls = true
    }, 1500);

    // $(this.vid).mouseover(function () {
    //     $(this).prop({ controls: true })
    // })
  }

  pauseVideo(videoId: any) {
    this.vid = document.getElementById("video" + videoId);

    this.vid.pause()
    this.vid.controls = false
  }
}
