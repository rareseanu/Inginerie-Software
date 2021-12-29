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