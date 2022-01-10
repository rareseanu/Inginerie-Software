export class Ticket {
    constructor(userID: number, purchasedDate: Date, departureID: number, wagonNumber: number, seatNumber: number, price: number,
            departureDate: Date) {
        this.userID = userID;
        this.purchasedDate = purchasedDate;
        this.departureID = departureID;
        this.wagonNumber = wagonNumber;
        this.seatNumber = seatNumber;
        this.departureDate = departureDate;
        this.price = price;
    }
    public userID: number;
    public purchasedDate: Date;
    public departureID: number;
    public wagonNumber: number;
    public seatNumber: number;
    public departureDate: Date;
    public price: number;
    public departureStationName: string;
    public destinationStationName: string;
}