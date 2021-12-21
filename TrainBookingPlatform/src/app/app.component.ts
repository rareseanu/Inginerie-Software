import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from './shared/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'TrainBookingPlatform';
  toggleRegister = false;

  ngOnInit() {
    this.authenticationService.refreshToken().subscribe();
  }

  constructor(public authenticationService: AuthenticationService) {}

  public logout() {
    this.authenticationService.logout().subscribe();
  }
}
