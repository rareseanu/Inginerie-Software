import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { UserInfo } from "./user-info.model";

@Injectable({providedIn: 'root'})
export class UserService{

    constructor(private http:HttpClient){

    }

    getUserInfo(id:number){
        return this.http.get(`https://localhost:44367/api/user/${id}`, { withCredentials: true });
    }

    updateUser(newUser:UserInfo){
        this.http.post<Response>(`https://localhost:44367/api/user/`, newUser, { withCredentials: true }).subscribe();
    }
}