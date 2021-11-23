import { Component } from '@angular/core';
import { AuthenticationService } from './shared/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'TrainBookingPlatform';
  toggleRegister = false;

  constructor(public authenticationService: AuthenticationService) {}

  public logout() {
    this.authenticationService.logout();
  }
}
