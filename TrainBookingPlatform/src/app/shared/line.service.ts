import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { tap } from "rxjs";
import { Line } from "./line.model";
import { RouteService } from "./route.service";
import { ToastService } from "./toast.service";

@Injectable({ providedIn: 'root' })
export class LineService {
    dataSource: Line[] = [];

    constructor(private http: HttpClient, private toastService: ToastService) { }

    getLines() {
        this.http.get(`https://localhost:44367/api/line/`, { withCredentials: true })
            .subscribe(data => {
                this.dataSource = <Line[]>data;
            });
    }

    remove(data: any) {
        var line: Line = data.data;
        this.http.delete(`https://localhost:44367/api/line/${line.id}`, { withCredentials: true, responseType: 'text' }).pipe(
            tap((message) => {
                this.getLines();
                if (message == "removed") {
                    this.toastService.addToast("Success!", "Line removed successfully!")
                }
                else {
                    this.toastService.addToast("Error!", "Something went wrong.")
                }
            }),
        ).subscribe();
    }

    add(data: any) {
        var line: Line = data.data;
        this.http.post(`https://localhost:44367/api/line/`, line, { withCredentials: true, responseType: 'text' }).pipe(
            tap((message) => {
                this.getLines();
                if (message == "added") {
                    this.toastService.addToast("Success!", "Line added successfully!")
                }
                else {
                    this.toastService.addToast("Error!", "Something went wrong.")
                }
            }),
        ).subscribe();
    }

    update(data: any) {
        var line: Line = Object.assign(data.oldData, data.newData);
        this.http.put(`https://localhost:44367/api/line/`, line, { withCredentials: true, responseType: 'text' }).pipe(
            tap((message) => {
                this.getLines();
                if (message == "updated") {
                    this.toastService.addToast("Success!", "Line updated successfully!")
                }
                else {
                    this.toastService.addToast("Error!", "Something went wrong.")
                }
            }),
        ).subscribe();
    }
}
