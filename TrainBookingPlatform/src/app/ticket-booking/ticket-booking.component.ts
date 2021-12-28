import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DepartureService } from '../shared/departure.service';
import { RouteService } from '../shared/route.service';
import { StationService } from '../shared/station.service';

@Component({
  selector: 'app-ticket-booking',
  templateUrl: './ticket-booking.component.html',
  styleUrls: ['./ticket-booking.component.css']
})
export class TicketBookingComoponent implements OnInit {
    bookingForm: FormGroup;
    submitted = false;
    get f() { return this.bookingForm.controls; }

    constructor(public stationService: StationService, public routeService: RouteService,
        public departureService: DepartureService) { }

    ngOnInit(): void {
        this.bookingForm = new FormGroup({
            departureStation: new FormControl('', Validators.required),
            arrivalStation: new FormControl({value: '', disabled: true}, Validators.required),
            route: new FormControl('', Validators.required),
            train: new FormControl('', Validators.required),
            departure: new FormControl('', Validators.required),
            wagon: new FormControl('', Validators.required),
            seat: new FormControl('', Validators.required)
        })

        this.routeService.dataSource = [];
        this.stationService.getStations();
    }

    onSubmit(): void {
        console.log(this.f)
    }

    onDepartureStationChanged() {
        this.f['arrivalStation'].enable();
    }

    onArrivalStationChanged() {
        this.routeService.getRoutesByStations(this.f['departureStation'].value.id, this.f['arrivalStation'].value.id);
        console.log(this.f['arrivalStation']);
    }

    onRouteChanged() {
        this.departureService.getDeparturesByRouteId(this.f['route'].value);
    }
}