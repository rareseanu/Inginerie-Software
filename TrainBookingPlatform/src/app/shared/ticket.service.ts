import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Wagon } from "./wagon.model";
import { Ticket } from "./ticket.model";

@Injectable({providedIn: 'root'})
export class TicketService {
    dataSource: Ticket[] = [];

    constructor(private http: HttpClient) { }

    getTicketsByDeparture(departureID: number) {
        return this.http.get(`https://localhost:44367/api/ticket/by-departure/${departureID}`, { withCredentials: true });
    }

    addTicket(ticket: Ticket) {
        this.http.post(`https://localhost:44367/api/ticket/`, ticket, { withCredentials: true, responseType: 'text' })
            .subscribe();
    }

    getTickets() {
        this.http.get(`https://localhost:44367/api/ticket/`, { withCredentials: true })
        .subscribe(data => this.dataSource = <Ticket[]>data);
    }
}