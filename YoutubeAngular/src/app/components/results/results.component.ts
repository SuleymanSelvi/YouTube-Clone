import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ServicesService } from 'src/app/services/services.service';
import * as $ from 'jquery';

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.css']
})
export class ResultsComponent {

  constructor(private services: ServicesService, private route: ActivatedRoute) { }

  videoList: any
  filterDisplay: boolean = false
  queryString: any
  date : any
  duration: any
  sortBy: any
 
  ngOnInit() {
    this.route.queryParams.subscribe(queryParams => {
      this.queryString = queryParams['search_query'];
      this.date = queryParams['date'];
      this.duration = queryParams['duration'];
      this.sortBy = queryParams['sortBy'];

      this.services.searchVideo(this.queryString,this.date, this.duration, this.sortBy).subscribe((res: any) => {
        if (res.success) {
          this.videoList = res.dataList
        }
        else if(!res.success){
          this.videoList == null
        }
      })

    })
  }

  filterDiv() {
    this.filterDisplay = !this.filterDisplay
  }

  // filters(title: any, value: any) {

  //   const date = new Date()
  //   const today = date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + (date.getDay() + 25)
  //   const aWeekAgo = date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + (date.getDay() + 18)
  //   const aMonthAgo = date.getFullYear() + '-' + date.getMonth() + '-' + (date.getDay() + 25)
  //   const aYearAgo = (date.getFullYear() - 1) + '-' + (date.getMonth() + 1) + '-' + (date.getDay() + 25)

  //   // DATE
  //   // if (title == "date") {
  //   //   if (value == "today") {
  //   //     this.videoList = this.videoList.filter((x: any) => x.createdDate > today);
  //   //   }
  //   //   else if (value == "week") {  
  //   //     this.videoList = this.videoList.filter((x: any) => x.createdDate > aWeekAgo && x.createdDate > today);
  //   //   }
  //   //   else if (value == "month") {
  //   //     this.videoList = this.videoList.filter((x: any) => x.createdDate > aMonthAgo && x.createdDate < today);
  //   //   }
  //   //   else if (value == "year") {
  //   //     this.videoList = this.videoList.filter((x: any) => x.createdDate < aYearAgo && x.createdDate < today);
  //   //   }
  //   // }

  //   // // DURATION
  //   // if (title == "duration") {
  //   //   if (value == "max4") {
  //   //     this.videoList = this.videoList.filter((x: any) => x.videoDuration < 400);
  //   //   }
  //   //   else if (value == "between") {
  //   //     this.videoList = this.videoList.filter((x: any) => x.videoDuration > 400 && x.videoDuration < 2000);
  //   //   }
  //   //   else if (value == "min20") {
  //   //     this.videoList = this.videoList.filter((x: any) => x.videoDuration > 3000);
  //   //   }
  //   // }


  //   // // SORT BY
  //   // if (title == "sortBy") {
  //   //   if (value == "date") {
  //   //     this.videoList = this.videoList.sort((a: any, b: any) => b.createdDate - a.createdDate);
  //   //   }
  //   //   else if (value == "view") {
  //   //     this.videoList = this.videoList.sort((a: any, b: any) => b.videoView - a.videoView);
  //   //   }
  //   //   else if (value == "rating") {
  //   //     this.videoList = this.videoList.sort((a: any, b: any) => a.likeCount - b.likeCount);
  //   //   }
  //   // }

  // }
}
