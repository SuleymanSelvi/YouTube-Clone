import { Component } from '@angular/core';
import { ServicesService } from 'src/app/services/services.service';

@Component({
  selector: 'app-registir',
  templateUrl: './registir.component.html',
  styleUrls: ['./registir.component.css']
})
export class RegistirComponent {

  constructor(private services: ServicesService) { }

  registerError: any

  ngOnInit(): void {
  }

  registir(name: any, password: any, about: any) {

    let formData = new FormData()
    formData.append("name", name)
    formData.append("password", password)
    formData.append("about", about)

    this.services.registir(name, password, about).subscribe((res: any) => {
      if (res.success) {
        localStorage.setItem("session", JSON.stringify(res.data))
        location.href = "/"
      }
      else {
        this.registerError = res.message
      }
    })
  }

}
