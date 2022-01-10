import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Station } from "./station.model";
import { tap } from "rxjs";
import { ToastService } from "./toast.service";

@Injectable({ providedIn: 'root' })
export class StationService {
    dataSource: Station[] = [];

    constructor(private http: HttpClient, private toastService: ToastService) { }

    getStations() {
        this.http.get(`https://localhost:44367/api/station/`, { withCredentials: true })
            .subscribe(data => this.dataSource = <Station[]>data);
    }

    remove(data: any) {
        var station: Station = data.data;
        this.http.delete(`https://localhost:44367/api/station/${station.id}`, { withCredentials: true, responseType: 'text' }).pipe(
            tap((message) => {

                this.getStations();
                if (message == "removed") {
                    this.toastService.addToast("Success!", "Station removed successfully!")
                }
                else {
                    this.toastService.addToast("Error!", "Something went wrong.")
                }
            }),
        ).subscribe();
    }

    add(data: any) {
        var station: Station = data.data;
        this.http.post(`https://localhost:44367/api/station/`, station, { withCredentials: true, responseType: 'text' }).pipe(
            tap((message) => {
                this.getStations();
                if (message == "added") {
                    this.toastService.addToast("Success!", "Station added successfully!")
                }
                else {
                    this.toastService.addToast("Error!", "Something went wrong.")
                }

            }),
        ).subscribe();
    }

    update(data: any) {
        var station: Station = Object.assign(data.oldData, data.newData);
        this.http.put(`https://localhost:44367/api/station/`, station, { withCredentials: true, responseType: 'text' }).pipe(
            tap((message) => {
                this.getStations();
                if (message == "updated") {
                    this.toastService.addToast("Success!", "Station updated successfully!")
                }
                else {
                    this.toastService.addToast("Error!", "Something went wrong.")
                }
            }),
        ).subscribe();
    }
}
