import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Wagon } from "./wagon.model";

@Injectable({providedIn: 'root'})
export class WagonService {
    dataSource: Wagon[] = [];

    constructor(private http: HttpClient) { }

    getWagonsByTrainId(trainID: number) {
        this.http.get(`https://localhost:44367/api/wagon/by-train/${trainID}`, { withCredentials: true })
            .subscribe(data => this.dataSource = <Wagon[]>data);
    }
}