import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserInfo } from '../shared/user-info.model';
import { AuthenticationService } from '../shared/authentication.service';
import { HttpClient } from "@angular/common/http";
import { Response } from '../shared/response.model';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  profileForm: FormGroup;
  submitted = false;
  get f() { return this.profileForm.controls; }

  constructor(private http: HttpClient,public authenticationService: AuthenticationService){

  }

  ngOnInit() {
    this.profileForm = new FormGroup({
      name: new FormControl('', Validators.required),
      "phone-number": new FormControl('', Validators.required),
      "old-password": new FormControl(''),
      "new-password": new FormControl(''),
      "new-password-again": new FormControl('')
    });
    if(this.authenticationService.getCurrentUser != null){
      this.getUserInfo();
    }
  }

  getUserInfo(){
    this.http.get(`https://localhost:44367/api/user/${this.authenticationService.getCurrentUser?.userId}`, { withCredentials: true })
      .subscribe(data => 
        {
          let userInfo : UserInfo;
          userInfo = <UserInfo>(<Response>data).value;
          this.f["name"].setValue(userInfo.name);
          this.f["phone-number"].setValue(userInfo.phoneNumber);         
        }
      );
  }

  needNewPassword() : boolean{
    if(this.f["old-password"].value != "" && this.f["new-password"].value == ""){
      return true;
    }
    return false;
  }

  newPasswordAgainInvalid() : boolean{
    if(this.f["new-password"].value != this.f["new-password-again"].value){
      return true;
    }
    return false;
  }

  onSubmit() {
    this.submitted = true;

    if (this.profileForm.invalid) {
        return;
    }

    var newUser : UserInfo = new UserInfo;
    if(this.authenticationService.getCurrentUser != null){
      newUser.id = this.authenticationService.getCurrentUser.userId;
      newUser.roleId = this.authenticationService.getCurrentUser.roleId;
      newUser.emailAddress = this.authenticationService.getCurrentUser.email;
      newUser.name = this.f["name"].value;
      newUser.phoneNumber = this.f["phone-number"].value;
      newUser.oldPassword = this.f["old-password"].value;
      newUser.newPassword = this.f["new-password"].value;

      this.http.post<Response>(`https://localhost:44367/api/user/`, newUser, { withCredentials: true }).subscribe();
    }



  } 

}
