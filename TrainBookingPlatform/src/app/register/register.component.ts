import { Component, OnInit } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Credentials } from '../credentials';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../shared/authentication.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  submitted = false;
  registered = false;
  get f() { return this.registerForm.controls; }

  constructor(public authenticationService: AuthenticationService) {
  }

  ngOnInit() {
    this.registerForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', Validators.required)
    })
    this.authenticationService.refreshToken().subscribe();
  }

  onSubmit() {
    this.submitted = true;

    if (this.registerForm.invalid) {
        return;
    }

    this.authenticationService.register(this.f['email'].value, this.f['password'].value)
        .subscribe(
            (data) => {
              if(data != null){
                this.registered = true;
                console.log(data);
              }
            },
            (error) => {
              console.log(error);
            });
  } 
}
