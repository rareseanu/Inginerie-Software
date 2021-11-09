import { Component, OnInit } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Credentials } from '../credentials';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  credentials: Credentials = {
    email: "",
    password: ""
  }

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
  }


  onRegister(): void {
    console.log(this.credentials);
    var postData = {
      email: '',
      password: 'email@email.com'
    };

    const headers: HttpHeaders = new HttpHeaders();
    headers.set('Content-Type', 'application/x-www-form-urlencoded');

    this.http.post('/UserRole/SaveUserRoles', postData, { headers: headers })
      .subscribe(result => {
      });
  }
}
