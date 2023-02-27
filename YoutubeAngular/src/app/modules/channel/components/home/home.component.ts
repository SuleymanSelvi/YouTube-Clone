import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ServicesService } from 'src/app/services/services.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent {

  constructor(private services: ServicesService, private route: ActivatedRoute) { }

  session: any
  channelName: any
  user: any

  nullId: any

  ngOnInit(): void {
    const session: any = localStorage.getItem('session')
    this.session = JSON.parse(session)

    this.channelName = this.route.snapshot.paramMap.get('name')

    this.getUserDetail()
  }

  getUserDetail() {
    if (this.session != null) {
      this.nullId = this.session.id
    }
    else {
      this.nullId = "0"
    }

    this.services.getUserDetail(this.channelName, this.nullId).subscribe((res: any) => {
      if (res.success) {
        this.user = res.data
      }
    })

  }

  newSubscribers(followedId: any) {
    if (this.session != null) {
      this.services.subscribers(followedId, this.session.id).subscribe((res: any) => {
        if (res.success) {
          this.user.isSubscribers = res.optionalBoolean
          this.user.channelSubscribersCount = res.optionalCount
        }
      })
    }
    else {
      location.href = "/login"
    }
  }

}