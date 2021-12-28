import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Station } from "./station.model";
import { tap } from "rxjs";
import { Departure } from "./departure.model";

@Injectable({ providedIn: 'root' })
export class DepartureService {
    dataSource: Departure[] = [];

    constructor(private http: HttpClient) { }

    getDepartures() {
        this.http.get(`https://localhost:44367/api/departure/`, { withCredentials: true })
            .subscribe(data => this.dataSource = <Departure[]>data);
    }

    getDeparturesByRouteId(routeId: number) {
        this.http.get(`https://localhost:44367/api/departure/by-route/${routeId}`, { withCredentials: true })
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
        this.http.post(`https://localhost:44367/api/departure/`, departure, { withCredentials: true, responseType: 'text' }).pipe(
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