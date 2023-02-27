import { Component } from '@angular/core';
import { ServicesService } from 'src/app/services/services.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(private services: ServicesService) { }

  loginError: any

  ngOnInit(): void {
    const session : any = localStorage.getItem("session")

    if(session != null){
      location.href = "/"
    }
  }

  login(name: any, password: any) {
    this.services.login(name, password).subscribe((res: any) => {
      if (res.success) {
        localStorage.setItem("session", JSON.stringify(res.data))
        location.href = "/"
      }
      else {
        this.loginError = res.message
      }
    })
  }
}
