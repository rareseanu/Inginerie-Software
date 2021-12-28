import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { tap } from 'rxjs';
import { Train } from '../../shared/train.model';
import { Response } from '../../shared/response.model';

@Component({
  selector: 'train-devextreme',
  templateUrl: './train-devextreme.component.html',
  styleUrls: ['./train-devextreme.component.css']
})
export class TrainDevextremeComponent {
  dataSource: Train[];

  constructor(private http: HttpClient) {
    this.getTrains();
  }

  getTrains() {
    this.http.get(`https://localhost:44367/api/train/`, { withCredentials: true })
      .subscribe(data => 
        {
          this.dataSource = <Train[]>data;
        });
  }

  remove(data: any) {
    var train: Train = data.data;
    this.http.delete(`https://localhost:44367/api/train/${train.id}`, { withCredentials: true, responseType: 'text' }).pipe(
      tap(() => {
        this.getTrains();
      }),
    ).subscribe();
  }

  add(data: any) { 
    var train: Train = data.data;
    this.http.post(`https://localhost:44367/api/train/`, train, { withCredentials: true, responseType: 'text' }).pipe(
      tap(() => {
        this.getTrains();
      }),
    ).subscribe();
  }

  update(data: any) {
    var train: Train = Object.assign(data.oldData, data.newData);
    this.http.put(`https://localhost:44367/api/train/`, train, { withCredentials: true, responseType: 'text' }).pipe(
      tap(() => {
        this.getTrains();
      }),
    ).subscribe();
  }
}
