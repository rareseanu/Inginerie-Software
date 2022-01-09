import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Station } from "./station.model";
import { tap } from "rxjs";

@Injectable({ providedIn: 'root' })
export class StationService {
    dataSource: Station[] = [];

    constructor(private http: HttpClient) { }

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
        this.http.post(`https://localhost:44367/api/station/`, station, { withCredentials: true, responseType: 'text' }).pipe(
            tap(() => {
                this.getStations();
            }),
        ).subscribe();
    }

    update(data: any) {
        var station: Station = Object.assign(data.oldData, data.newData);
        this.http.put(`https://localhost:44367/api/station/`, station, { withCredentials: true, responseType: 'text' }).pipe(
            tap(() => {
                this.getStations();
            }),
        ).subscribe();
    }
}