export class SeatObject {
    constructor(seatNumber: number, isOccupied: boolean) {
        this.seatNumber = seatNumber;
        this.isOccupied = isOccupied;
    }
    public seatNumber: number;
    public isOccupied: boolean;
}