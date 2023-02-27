import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ServicesService } from 'src/app/services/services.service';
import * as $ from 'jquery'

@Component({
  selector: 'app-video-comments',
  templateUrl: './video-comments.component.html',
  styleUrls: ['./video-comments.component.css']
})
export class VideoCommentsComponent {

  constructor(private services: ServicesService, private route: ActivatedRoute) { }

  videoComments: any
  videoId: any
  session: any

  ngOnInit(): void {
    let session: any = localStorage.getItem("session")
    this.session = JSON.parse(session)

    this.videoId = this.route.snapshot.paramMap.get("id");

    this.getCommentsByVideoId()
  }

  getCommentsByVideoId() {
    this.services.getCommentByVideoId(this.videoId).subscribe((res: any) => {
      if (res.success) {
        this.videoComments = res.dataList
      }
    })
  }

  uploadComment(comment: any, subCommentId: any) {

    // const formData = new FormData()
    // formData.append("userId", this.videoId)
    // formData.append("videoId", this.videoId)
    // formData.append("comment", comment)
    // formData.append("subCommentId", subCommentId)

    if (this.session != null) {
      if (comment.length > 0) {
        this.services.uploadComment(this.session.id, this.videoId, comment, subCommentId).subscribe((res: any) => {
          if (res.success) {
            this.getCommentsByVideoId()
  
            // this.videoComments.push({
            //   'comment' : res.data.comment,
            //   'userId' : res.data.userId
            // })
          }
        })
      }
      else {
        $("#commentTextArea").focus()
      }
    }
    else{
      location.href = "/login"
    }
    
  }
}
