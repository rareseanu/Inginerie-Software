import { HttpClientModule } from '@angular/common/http';
import { APP_INITIALIZER, NgModule } from '@angular/core';
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
import { LineComponent } from './line/line.component';
import { LineDevextremeComponent } from './line/line-devextreme/line-devextreme.component';
import { RouteComponent } from './route/route.component';
import { RouteDevextremeComponent } from './route/route-devextreme/route-devextreme.component';
import { ToastComponent } from './shared/toast/toast.component';
import { TicketBookingComoponent } from './ticket-booking/ticket-booking.component';
import { UserComponent } from './user/user.component';
import { UserTicketComponent } from './user/user-ticket/user-ticket.component';
import { QRCodeModule } from 'angular2-qrcode';

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
    LineComponent,
    LineDevextremeComponent,
    RouteComponent,
    RouteDevextremeComponent,
    ToastComponent,
    TicketBookingComoponent,
    UserComponent,
    UserTicketComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    DxDataGridModule,
    QRCodeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
