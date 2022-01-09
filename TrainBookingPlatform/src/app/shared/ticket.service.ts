import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Wagon } from "./wagon.model";
import { Ticket } from "./ticket.model";

@Injectable({providedIn: 'root'})
export class TicketService {
    dataSource: Ticket[] = [];

    constructor(private http: HttpClient) { }

    getTicketsByDeparture(departureID: number, departureDate: Date) {
        console.log(departureDate);
        return this.http.get(`https://localhost:44367/api/ticket/by-departure/${departureID}?departureDate=${new Date(departureDate).getTime()}`, { withCredentials: true });
    }

    addTicket(ticket: Ticket) {
        this.http.post(`https://localhost:44367/api/ticket/`, ticket, { withCredentials: true, responseType: 'text' })
            .subscribe();
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