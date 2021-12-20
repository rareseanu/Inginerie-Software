import { HttpClient } from '@angular/common/http';
import { NgModule, Component, enableProdMode } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { Observable, tap } from 'rxjs';
import { Station } from 'src/app/shared/station.model';

if (!/localhost/.test(document.location.host)) {
  enableProdMode();
}

@Component({
  selector: 'station-devextreme',
  templateUrl: './station-devextreme.component.html',
  styleUrls: ['./station-devextreme.component.css'],
})

export class StationDevextremeComponent {
  dataSource: Station[];

  // states: State[];

  constructor(private http: HttpClient) {
    this.getStations();
  }

  getStations() {
    this.http.get(`https://localhost:44367/api/station/`, { withCredentials: true })
      .subscribe(data => this.dataSource = <Station[]>data);
  }

  remove(data: any) {
    var station: Station = data.data;
    this.http.delete(`https://localhost:44367/api/station/${station.id}`, { withCredentials: true, responseType: 'text' }).pipe(
      tap(() => {
        this.getStations();
      }),
    ).subscribe();
  }

  add(data: any) {
    var station: Station = data.data;
    this.http.post(`https://localhost:44367/api/station/`, station, { withCredentials: true, responseType: 'text'}).pipe(
      tap(() => {
        this.getStations();
      }),
    ).subscribe();
  }

  update(data: any) {
    var station: Station = Object.assign(data.oldData, data.newData);
    console.log(station);
    this.http.put(`https://localhost:44367/api/station/`, station, { withCredentials: true, responseType: 'text' }).pipe(
      tap(() => {
        this.getStations();
      }),
    ).subscribe();
  }
}
