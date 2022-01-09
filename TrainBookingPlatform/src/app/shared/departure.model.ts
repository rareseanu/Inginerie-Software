import { Time } from "@angular/common";
import { Line } from "./line.model";

export class Departure {
    public id: number;
    public lineId: number;
    public departureTime: Time;
    public arrivalTime: Time;
    public trainId: number;
    public line: Line;
}