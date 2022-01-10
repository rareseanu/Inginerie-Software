import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Wagon } from "./wagon.model";
import { Ticket } from "./ticket.model";
import { ToastService } from "./toast.service";
import { tap } from "rxjs";

@Injectable({providedIn: 'root'})
export class TicketService {
    dataSource: Ticket[] = [];

    constructor(private http: HttpClient, private toastService: ToastService) { }

    getTicketsByDeparture(departureID: number, departureDate: Date) {
        return this.http.get(`https://localhost:44367/api/ticket/by-departure/${departureID}?departureDate=${new Date(departureDate).getTime()}`, { withCredentials: true });
    }

    addTicket(ticket: Ticket) {
        this.http.post(`https://localhost:44367/api/ticket/`, ticket, { withCredentials: true, responseType: 'text' }).pipe(
            tap((message) => {
                if (message == "added") {
                    this.toastService.addToast("Success!", "Ticket booked successfully!")
                }
                else {
                    this.toastService.addToast("Error!", "Something went wrong.")
                }

            }),
        ).subscribe();
    }

    getTickets() {
        this.http.get(`https://localhost:44367/api/ticket/`, { withCredentials: true })
        .subscribe(data => this.dataSource = <Ticket[]>data);
    }

    getUserTickets(id:number){
        this.http.get(`https://localhost:44367/api/ticket/user/${id}`, { withCredentials: true })
        .subscribe(data => 
            {
                this.dataSource = <Ticket[]>data;
            });
    }
}