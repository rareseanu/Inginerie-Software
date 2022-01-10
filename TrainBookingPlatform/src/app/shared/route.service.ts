import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { tap } from "rxjs";
import { Line } from "./line.model";
import { Route } from "./route.model";

@Injectable({ providedIn: 'root' })
export class RouteService {
    dataSource: Route[] = [];

    constructor(private http: HttpClient) { }

    getRoutes() {
        this.http.get(`https://localhost:44367/api/route/`, { withCredentials: true })
            .subscribe(data => {
                this.dataSource = <Route[]>data;
            });
    }

    remove(data: any) {
        var route: Route = data.data;
        this.http.delete(`https://localhost:44367/api/route/${route.id}`, { withCredentials: true, responseType: 'text' }).pipe(
            tap(() => {
                this.getRoutes();
                 if(data=="removed") {
                  this.toastService.addToast("Succes!", "Route removed successfully!")
                }
                else {
                  this.toastService.addToast("Error!", "Something went wrong.")
                }
            }),
        ).subscribe();
    }

    add(data: any) {
        var route: Route = data.data;
        this.http.post(`https://localhost:44367/api/route/`, route, { withCredentials: true, responseType: 'text' }).pipe(
            tap(() => {
                this.getRoutes();
                 if(data=="added") {
                  this.toastService.addToast("Succes!", "Route added successfully!")
                }
                else {
                  this.toastService.addToast("Error!", "Something went wrong.")
                }
            }),
        ).subscribe();
    }

    getRoutesByStations(departureStationId: number, destinationStationId: number) {
        this.http.get(`https://localhost:44367/api/line/by-stations?departureStationId=${departureStationId}&destinationStationId=${destinationStationId}`, { withCredentials: true })
            .subscribe(data => {
                this.dataSource = <Route[]>data;
            });
    }

    update(data: any) {
        var route: Route = Object.assign(data.oldData, data.newData);
        this.http.put(`https://localhost:44367/api/route/`, route, { withCredentials: true, responseType: 'text' }).pipe(
            tap(() => {
                this.getRoutes();
                 if(data=="updated") {
                  this.toastService.addToast("Succes!", "Route updated successfully!")
                }
                else {
                  this.toastService.addToast("Error!", "Something went wrong.")
                }
            }),
        ).subscribe();
    }
}
