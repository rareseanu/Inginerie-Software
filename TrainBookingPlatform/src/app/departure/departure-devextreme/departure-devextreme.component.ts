import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { tap } from 'rxjs';
import { Departure } from 'src/app/shared/departure.model';
import { DepartureService } from 'src/app/shared/departure.service';
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
  constructor(public departureService: DepartureService, public trainService: TrainService, public routeService: RouteService) {

  }

  ngOnInit() {
    this.departureService.getDepartures();
    this.routeService.getRoutes();
    this.trainService.getTrains();
  }
}
