import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Station } from "./station.model";
import { tap } from "rxjs";
import { Train } from "./train.model";
import { ToastService } from "./toast.service";


@Injectable({ providedIn: 'root' })
export class TrainService {
  dataSource: Train[] = [];

  constructor(private http: HttpClient, private toastService: ToastService) { }

  getTrains() {
    this.http.get(`https://localhost:44367/api/train/`, { withCredentials: true })
      .subscribe(data => {
        this.dataSource = <Train[]>data;
      });
  }

  remove(data: any) {
    var train: Train = data.data;
    this.http.delete(`https://localhost:44367/api/train/${train.id}`, { withCredentials: true, responseType: 'text' }).pipe(
      tap((message) => {
        this.getTrains();
        if (message == "removed") {
          this.toastService.addToast("Succes!", "Train removed successfully!")
        }
        else {
          this.toastService.addToast("Error!", "Something went wrong.")
        }
      }),
    ).subscribe();
  }

  add(data: any) {
    var train: Train = data.data;
    this.http.post(`https://localhost:44367/api/train/`, train, { withCredentials: true, responseType: 'text' }).pipe(
      tap((message) => {
        this.getTrains();
        if (message == "added") {
          this.toastService.addToast("Success!", "Train added successfully!")
        }
        else {
          this.toastService.addToast("Error!", "Something went wrong.")
        }
      }),
    ).subscribe();
  }

  update(data: any) {
    var train: Train = Object.assign(data.oldData, data.newData);
    this.http.put(`https://localhost:44367/api/train/`, train, { withCredentials: true, responseType: 'text' }).pipe(
      tap((message) => {
        this.getTrains();
        if (message == "added") {
          this.toastService.addToast("Success!", "Train updated successfully!")
        }
        else {
          this.toastService.addToast("Error!", "Something went wrong.")
        }
      }),
    ).subscribe();
  }
}
