import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DepartureComponent } from './departure/departure.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { LineComponent } from './line/line.component';
import { RouteComponent } from './route/route.component';
import { AuthenticationGuard } from './shared/authentication.guard';
import { StationComponent } from './station/station.component';
import { TicketBookingComoponent } from './ticket-booking/ticket-booking.component';
import { TrainComponent } from './train/train.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  { path: 'user', component: UserComponent, canActivate: [AuthenticationGuard], data: {role: ['Administrator']}  },
  { path: 'departure', component: DepartureComponent, canActivate: [AuthenticationGuard], data: {role: ['Administrator']} },
  { path: 'line', component: LineComponent, canActivate: [AuthenticationGuard], data: {role: ['Administrator']}  },
  { path: 'route', component: RouteComponent, canActivate: [AuthenticationGuard], data: {role: ['Administrator']}  },
  { path: 'station', component: StationComponent, canActivate: [AuthenticationGuard], data: {role: ['Administrator']}  },
  { path: 'train', component: TrainComponent, canActivate: [AuthenticationGuard], data: {role: ['Administrator']}  },
  { path: 'ticket-booking', component: TicketBookingComoponent, canActivate: [AuthenticationGuard], data: {role: ['Client', 'Administrator']} },
  { path: '**', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
