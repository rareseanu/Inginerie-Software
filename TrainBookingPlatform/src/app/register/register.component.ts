import { Component, OnInit } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Credentials } from '../credentials';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
    email: string = "";
    password: string = ""

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
  }


  onRegister(): void {
    var postData = {
      email: this.email,
      password: this.password
    };

    const headers: HttpHeaders = new HttpHeaders();
    headers.set('Content-Type', 'application/json');
    
    this.http.put('https://localhost:44367/api/user/register', postData, { headers: headers })
      .subscribe(result => {
        console.log(result)
      });
  }
}
