import { Time } from "@angular/common";

export class Departure {
    public id: number;
    public routeId: number;
    public departureTime: Time;
    public arrivalTime: Time;
    public trainId: number;
}