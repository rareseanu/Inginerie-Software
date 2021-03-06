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

  constructor(public authenticationService: AuthenticationService) {}

  ngOnInit() {
  }

  public logout() {
    this.authenticationService.logout().subscribe();
  }
}
