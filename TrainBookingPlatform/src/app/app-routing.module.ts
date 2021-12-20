import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DepartureComponent } from './departure/departure.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { RouteComponent } from './route/route.component';
import { StationComponent } from './station/station.component';
import { TicketComponent } from './ticket/ticket.component';
import { TrainComponent } from './train/train.component';

const routes: Routes = [
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  { path: 'departure', component: DepartureComponent },
  { path: 'route', component: RouteComponent },
  { path: 'station', component: StationComponent },
  { path: 'ticket', component: TicketComponent },
  { path: 'train', component: TrainComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
