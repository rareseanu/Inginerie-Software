import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Station } from "./station.model";
import { tap } from "rxjs";
import { Departure } from "./departure.model";

@Injectable({ providedIn: 'root' })
export class DepartureService {
    dataSource: Departure[] = [];
    dataSource2: Departure[] = [];

    constructor(private http: HttpClient) { }

    getDepartures() {
        this.http.get(`https://localhost:44367/api/departure/`, { withCredentials: true })
            .subscribe(data => this.dataSource = <Departure[]>data);
    }

    getDeparturesByRouteId(routeId: number, departureStationId: number) {
        this.http.get(`https://localhost:44367/api/departure/by-route/${routeId}?departureStationId=${departureStationId}`, { withCredentials: true })
            .subscribe(data => {
                this.dataSource = <Departure[]>data;
            });
    }

    getDeparturesByRouteAndDestinationId(routeId: number, destinationId: number) {
        this.http.get(`https://localhost:44367/api/departure/by-route2/${routeId}?destinationStationId=${destinationId}`, { withCredentials: true })
            .subscribe(data => {
                this.dataSource2 = <Departure[]>data;
            });
    }

    remove(data: any) {
        var departure: Departure = data.data;
        this.http.delete(`https://localhost:44367/api/departure/${departure.id}`, { withCredentials: true, responseType: 'text' }).pipe(
            tap(() => {
                this.getDepartures();
                 if(data=="removed") {
                  this.toastService.addToast("Succes!", "Departure removed successfully!")
                }
                else {
                  this.toastService.addToast("Error!", "Something went wrong.")
                }
            }),
        ).subscribe();
    }

    add(data: any) {
        var departure: Departure = data.data;
        this.http.post(`https://localhost:44367/api/departure/`, departure, { withCredentials: true, responseType: 'text' }).pipe(
            tap(() => {
                this.getDepartures();
                 if(data=="added") {
                  this.toastService.addToast("Succes!", "Departure added successfully!")
                }
                else {
                  this.toastService.addToast("Error!", "Something went wrong.")
                }
            }),
        ).subscribe();
    }

    update(data: any) {
        var departure: Departure = Object.assign(data.oldData, data.newData);
        this.http.put(`https://localhost:44367/api/departure/`, departure, { withCredentials: true, responseType: 'text' }).pipe(
            tap(() => {
                this.getDepartures();
                 if(data=="updated") {
                  this.toastService.addToast("Succes!", "Departure updated successfully!")
                }
                else {
                  this.toastService.addToast("Error!", "Something went wrong.")
                }
            }),
        ).subscribe();
    }
}
