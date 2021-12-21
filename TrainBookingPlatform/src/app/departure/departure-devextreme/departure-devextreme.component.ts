import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { tap } from 'rxjs';
import { Departure } from 'src/app/shared/departure.model';
import { Route } from 'src/app/shared/route.model';
import { Station } from 'src/app/shared/station.model';
import { Train } from 'src/app/shared/train.model';

@Component({
  selector: 'departure-devextreme',
  templateUrl: './departure-devextreme.component.html',
  styleUrls: ['./departure-devextreme.component.css']
})
export class DepartureDevextremeComponent {
  dataSource: Departure[];
  routes: Route[];
  trains: Train[];

  constructor(private http: HttpClient) {
    this.getRoutes();
    this.getTrains();
    this.getDepartures();
  }

  getRoutes() {
    this.http.get(`https://localhost:44367/api/route/`, { withCredentials: true })
      .subscribe(data => this.routes = <Route[]>data);
  }

  getTrains() {
    this.http.get(`https://localhost:44367/api/train/`, { withCredentials: true })
      .subscribe(data => this.trains = <Train[]>data);
  }

  getDepartures() {
    this.http.get(`https://localhost:44367/api/departure/`, { withCredentials: true })
      .subscribe(data => this.dataSource = <Departure[]>data);
  }

  remove(data: any) {
    var departure: Departure = data.data;
    this.http.delete(`https://localhost:44367/api/departure/${departure.id}`, { withCredentials: true, responseType: 'text' }).pipe(
      tap(() => {
        this.getDepartures();
      }),
    ).subscribe();
  }

  add(data: any) {
    var departure: Departure = data.data;
    this.http.post(`https://localhost:44367/api/departure/`, departure, { withCredentials: true, responseType: 'text'}).pipe(
      tap(() => {
        this.getDepartures();
      }),
    ).subscribe();
  }

  update(data: any) {
    var departure: Departure = Object.assign(data.oldData, data.newData);
    console.log(departure);
    this.http.put(`https://localhost:44367/api/departure/`, departure, { withCredentials: true, responseType: 'text' }).pipe(
      tap(() => {
        this.getDepartures();
      }),
    ).subscribe();
  }
}
