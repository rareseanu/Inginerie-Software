import { Component, Input, OnInit } from '@angular/core';
import { Ticket } from 'src/app/shared/ticket.model';
import { TicketService } from 'src/app/shared/ticket.service';

@Component({
  selector: 'app-user-ticket',
  templateUrl: './user-ticket.component.html',
  styleUrls: ['./user-ticket.component.css']
})
export class UserTicketComponent implements OnInit {

  @Input()
  public ticket:Ticket;
  @Input()
  public ticketNo:number;

  constructor(public ticketService:TicketService) { }

  ticketToJson(){
    return JSON.stringify(this.ticket);
  }

  ngOnInit(): void {
  }

}
