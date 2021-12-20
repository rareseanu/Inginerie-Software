import { Station } from "./station.model";

export class Route {
    public id: number;
    public destinationStation: Station;
    public departureStation: Station;
    public name: string;
    constructor() {
        this.name = this.destinationStation.name + "-" + this.destinationStation.name;
    }
}