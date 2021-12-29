import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { find, tap } from 'rxjs';
import { RouteService } from 'src/app/shared/route.service';

@Component({
  selector: 'route-devextreme',
  templateUrl: './route-devextreme.component.html',
  styleUrls: ['./route-devextreme.component.css']
})

export class RouteDevextremeComponent {

  ngOnInit() {
    this.routeService.getRoutes();
  }

  constructor(private http: HttpClient,public routeService: RouteService) {
    this.routeService.getRoutes();
  }

}
