import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  onRegister(): void {
    
    this.http.post<any>('https://localhost:44367/api/user/register', { title: 'Angular POST Request Example' }).subscribe(data => {
        console.log(data);
    })
  }

}
