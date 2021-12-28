import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { tap } from 'rxjs';
import { Train } from 'src/app/shared/train.model';
import { TrainService } from 'src/app/shared/train.service';

@Component({
  selector: 'train-devextreme',
  templateUrl: './train-devextreme.component.html',
  styleUrls: ['./train-devextreme.component.css']
})
export class TrainDevextremeComponent {

  constructor(public trainService: TrainService) {
    this.trainService.getTrains();
  }

}
