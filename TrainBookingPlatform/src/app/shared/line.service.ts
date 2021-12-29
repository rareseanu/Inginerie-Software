import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { tap } from "rxjs";
import { Line } from "./line.model";

@Injectable({ providedIn: 'root' })
export class LineService {
    dataSource: Line[] = [];

    constructor(private http: HttpClient) { }

    getLines() {
        this.http.get(`https://localhost:44367/api/line/`, { withCredentials: true })
            .subscribe(data => {
                this.dataSource = <Line[]>data;
            });
    }

    getRoutesByStations(departureStationId: number, destinationStationId: number) {
        this.http.get(`https://localhost:44367/api/line/by-stations?departureStationId=${departureStationId}&destinationStationId=${destinationStationId}`, { withCredentials: true })
            .subscribe(data => {
                this.dataSource = <Line[]>data;
            });
    }

    remove(data: any) {
        var line: Line = data.data;
        this.http.delete(`https://localhost:44367/api/line/${line.id}`, { withCredentials: true, responseType: 'text' }).pipe(
            tap(() => {
                this.getLines();
            }),
        ).subscribe();
    }

    add(data: any) {
        var line: Line = data.data;
        this.http.post(`https://localhost:44367/api/line/`, line, { withCredentials: true, responseType: 'text' }).pipe(
            tap(() => {
                this.getLines();
            }),
        ).subscribe();
    }

    update(data: any) {
        var line: Line = Object.assign(data.oldData, data.newData);
        this.http.put(`https://localhost:44367/api/line/`, line, { withCredentials: true, responseType: 'text' }).pipe(
            tap(() => {
                this.getLines();
            }),
        ).subscribe();
    }
}