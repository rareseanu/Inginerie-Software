import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { find, tap } from 'rxjs';
import { Route } from 'src/app/shared/route.model';
import { RouteService } from 'src/app/shared/route.service';
import { Station } from 'src/app/shared/station.model';
import { StationService } from 'src/app/shared/station.service';

@Component({
  selector: 'route-devextreme',
  templateUrl: './route-devextreme.component.html',
  styleUrls: ['./route-devextreme.component.css']
})

export class RouteDevextremeComponent {

  ngOnInit() {
    this.routeService.getRoutes();
    this.stationService.getStations();
  }

  constructor(private http: HttpClient, public routeService: RouteService, public stationService: StationService) {
    this.routeService.getRoutes();
    this.stationService.getStations();
  }

}
