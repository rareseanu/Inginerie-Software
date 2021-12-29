import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RouteService } from 'src/app/shared/route.service';
import { LineService } from 'src/app/shared/line.service';
import { StationService } from 'src/app/shared/station.service';

@Component({
  selector: 'line-devextreme',
  templateUrl: './line-devextreme.component.html',
  styleUrls: ['./line-devextreme.component.css']
})

export class LineDevextremeComponent {

  ngOnInit() {
    this.lineService.getLines();
    this.stationService.getStations();
    this.routeService.getRoutes();
  }

  constructor(private http: HttpClient, public lineService: LineService, public stationService: StationService,public routeService: RouteService) {
    this.lineService.getLines();
    this.stationService.getStations();
    this.routeService.getRoutes();
  }

}
