import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ServicesService } from 'src/app/services/services.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  constructor(private services: ServicesService, private router: Router) { }

  session: any
  searchVideoList: any
  searchDiv: boolean = false;
  userDropdown: boolean = false;

  ngOnInit(): void {
    const session: any = localStorage.getItem("session");
    this.session = JSON.parse(session)
  }

  searchVideoByName(searchName: any) {
    searchName.length > 0 ? this.searchDiv = true : this.searchDiv = false

    setTimeout(() => {
      this.services.searchVideo(searchName, 0, 0, 0).subscribe((res: any) => {
        if (res.success) {
          this.searchVideoList = res.dataList
        }
      })
    }, 500);
  }

  routerLink(searchName: any) {
    this.searchDiv = false
    this.router.navigate(['/results'], { queryParams: { search_query: searchName } });
  }

  logOut() {
    localStorage.clear()
    location.reload()
  }

  userDropdownDiv() {
    this.userDropdown = !this.userDropdown
  }
}
