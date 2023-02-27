import { Component } from '@angular/core';
import { ServicesService } from 'src/app/services/services.service';

@Component({
  selector: 'app-sidebars',
  templateUrl: './sidebars.component.html',
  styleUrls: ['./sidebars.component.css']
})
export class SidebarsComponent {

  constructor(private services: ServicesService) { }

  session: any
  subscribersList: any
  nullSubscribers: boolean = false

  ngOnInit(): void {
    const session: any = localStorage.getItem("session")
    this.session = JSON.parse(session)

    this.getUserSubscribers()
  }

  getUserSubscribers() {
    this.services.getUserSubscribers(this.session.id).subscribe((res: any) => {
      if (res.success) {
        this.subscribersList = res.dataList.slice(0,4)
      }
      else if (!res.success) {
        this.nullSubscribers = true
      }
    })
  }
}
