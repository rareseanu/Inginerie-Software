import { Route } from "./route.model";
import { Train } from "./train.model";

export class Departure {
    public id: number;
    public route: Route;
    public departureTime: Date;
    public arrivalTime: Date;
    public train: Train;
}