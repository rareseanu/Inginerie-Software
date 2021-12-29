import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../shared/authentication.service';
import { DepartureService } from '../shared/departure.service';
import { RouteService } from '../shared/route.service';
import { SeatObject } from '../shared/seat-object.model';
import { StationService } from '../shared/station.service';
import { Ticket } from '../shared/ticket.model';
import { TicketService } from '../shared/ticket.service';
import { WagonService } from '../shared/wagon.service';

@Component({
  selector: 'app-ticket-booking',
  templateUrl: './ticket-booking.component.html',
  styleUrls: ['./ticket-booking.component.css']
})

export class TicketBookingComoponent implements OnInit {
    bookingForm: FormGroup;
    submitted = false;
    get f() { return this.bookingForm.controls; }

    seats: SeatObject[][] = [];

    constructor(public stationService: StationService, public routeService: RouteService,
        public departureService: DepartureService, public wagonService: WagonService,
        public authenticationService: AuthenticationService, public ticketService: TicketService) { }

    ngOnInit(): void {
        this.bookingForm = new FormGroup({
            departureStation: new FormControl('', Validators.required),
            arrivalStation: new FormControl({value: '', disabled: true}, Validators.required),
            route: new FormControl('', Validators.required),
            departure: new FormControl('', Validators.required),
            wagon: new FormControl({value: '', disabled: true}, Validators.required),
            seat: new FormControl({value: '', disabled: true}, Validators.required)
        })

        this.routeService.dataSource = [];
        this.stationService.getStations();
    }

    onSubmit(): void {
        if(this.authenticationService.getCurrentUser) {
            let ticket = new Ticket(this.authenticationService.getCurrentUser?.userId, new Date(),
                this.f['departure'].value.id, this.f['wagon'].value.number, this.f['seat'].value, 5);
            this.ticketService.addTicket(ticket);
        }
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

    onDepartureChanged() {
        console.log(this.f['departure'].value.trainId);
        this.wagonService.getWagonsByTrainId(this.f['departure'].value.trainId);
        this.f['wagon'].enable();   
    }

    onChooseSeatClicked() {
        this.seats = [];
        this.ticketService.getTicketsByDeparture(this.f['departure'].value.id).subscribe(data => {
            this.ticketService.dataSource = (<Ticket[]>data).filter(p => p.wagonNumber == this.f['wagon'].value.number);
            for(let i = 0; i < Math.ceil(this.f['wagon'].value.numberOfSeats / 4.0); ++i) {
                this.seats.push([]);
                for(let j = i * 4 + 1; j < i * 4 + 5; ++j) {
                    if(j <= this.f['wagon'].value.numberOfSeats) {
                        if(this.seatExists(j)) {
                            this.seats[i].push(new SeatObject(j, true));
                        } else {
                            this.seats[i].push(new SeatObject(j, false));
                        }
                    }
                }
            }
        });
    }

    seatExists(seat: any) {
        for(let ticket of this.ticketService.dataSource) {
            if(ticket.seatNumber == seat && ticket.wagonNumber == this.f['wagon'].value.number) {
                return true;
            }
        }
        return false;
    }

    onSeatClick(seatNumber: any) {
        this.f['seat'].setValue(seatNumber);
    }
}