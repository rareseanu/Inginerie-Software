import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { find, tap } from 'rxjs';
import { Route } from 'src/app/shared/route.model';
import { Station } from 'src/app/shared/station.model';

@Component({
  selector: 'route-devextreme',
  templateUrl: './route-devextreme.component.html',
  styleUrls: ['./route-devextreme.component.css']
})

export class RouteDevextremeComponent {
  dataSource: Route[];
  stations: Station[];


  constructor(private http: HttpClient) {
    this.getStations();
  }

  getRoutes() {
    this.http.get(`https://localhost:44367/api/route/`, { withCredentials: true })
      .subscribe(data => 
        {
          this.dataSource = <Route[]>data;
        });
  }

  getStations() {
    this.http.get(`https://localhost:44367/api/station/`, { withCredentials: true })
      .subscribe(data => 
        {
          this.stations = <Station[]>data;
          this.getRoutes();
        });
  }

  remove(data: any) {
    var route: Route = data.data;
    this.http.delete(`https://localhost:44367/api/route/${route.id}`, { withCredentials: true, responseType: 'text' }).pipe(
      tap(() => {
        this.getRoutes();
      }),
    ).subscribe();
  }

  add(data: any) { 
    var route: Route = data.data;
    this.http.post(`https://localhost:44367/api/route/`, route, { withCredentials: true, responseType: 'text' }).pipe(
      tap(() => {
        this.getRoutes();
      }),
    ).subscribe();
  }

  update(data: any) {
    var route: Route = Object.assign(data.oldData, data.newData);
    this.http.put(`https://localhost:44367/api/route/`, route, { withCredentials: true, responseType: 'text' }).pipe(
      tap(() => {
        this.getRoutes();
      }),
    ).subscribe();
  }
}
