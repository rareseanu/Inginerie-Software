import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { DxDataGridModule } from 'devextreme-angular';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { StationComponent } from './station/station.component';
import { StationDevextremeComponent } from './station/station-devextreme/station-devextreme.component';
import { TrainComponent } from './train/train.component';
import { TrainDevextremeComponent } from './train/train-devextreme/train-devextreme.component';
import { DepartureComponent } from './departure/departure.component';
import { DepartureDevextremeComponent } from './departure/departure-devextreme/departure-devextreme.component';
import { RouteComponent } from './route/route.component';
import { RouteDevextremeComponent } from './route/route-devextreme/route-devextreme.component';
import { ToastComponent } from './shared/toast/toast.component';
import { TicketBookingComoponent } from './ticket-booking/ticket-booking.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    StationComponent,
    StationDevextremeComponent,
    TrainComponent,
    TrainDevextremeComponent,
    DepartureComponent,
    DepartureDevextremeComponent,
    RouteComponent,
    RouteDevextremeComponent,
    ToastComponent,
    TicketBookingComoponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    DxDataGridModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
