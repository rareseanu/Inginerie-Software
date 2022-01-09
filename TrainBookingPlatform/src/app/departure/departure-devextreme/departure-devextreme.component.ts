import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { tap } from 'rxjs';
import { Departure } from 'src/app/shared/departure.model';
import { DepartureService } from 'src/app/shared/departure.service';
import { LineService } from 'src/app/shared/line.service';
import { Route } from 'src/app/shared/route.model';
import { RouteService } from 'src/app/shared/route.service';
import { Station } from 'src/app/shared/station.model';
import { Train } from 'src/app/shared/train.model';
import { TrainService } from 'src/app/shared/train.service';

@Component({
  selector: 'departure-devextreme',
  templateUrl: './departure-devextreme.component.html',
  styleUrls: ['./departure-devextreme.component.css']
})
export class DepartureDevextremeComponent {
  constructor(public departureService: DepartureService, public trainService: TrainService, public lineService: LineService) {

  }

  ngOnInit() {
    this.departureService.getDepartures();
    this.lineService.getLines();
    this.trainService.getTrains();
  }

  public displayExpr = (item: any) => {
    // "item" can be null
    return item && item.departureStationName + '-' + item.destinationStationName;
  }
}
