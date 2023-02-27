import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ServicesService } from 'src/app/services/services.service';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent {

  constructor(private services: ServicesService, private route: ActivatedRoute) { }

  session: any
  channelName: any
  user: any

  ngOnInit(): void {
    const session: any = localStorage.getItem('session')
    this.session = JSON.parse(session)

    this.channelName = this.route.snapshot.paramMap.get('name')

    this.services.getUserDetail(this.channelName, this.session.id).subscribe((res: any) => {
      if (res.success) {
        this.user = res.data
      }
    })
  }
}
