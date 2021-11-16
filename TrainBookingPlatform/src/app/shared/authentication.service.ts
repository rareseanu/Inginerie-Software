import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { BehaviorSubject, Observable, tap } from "rxjs";
import { User } from "./user.model";

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private currentUserSubject: BehaviorSubject<User | null>;
    public currentUser: Observable<User | null>;
    private refreshTokenTimeout: any;

    constructor(private http: HttpClient, private router: Router) {
        this.currentUserSubject = new BehaviorSubject<User | null>(null);
        this.currentUser = this.currentUserSubject.asObservable();
        this.currentUser.subscribe();
    }

    public get getCurrentUser() {
        return this.currentUserSubject.getValue();
    }

    public getCurrentUserEmail() {
        if(this.getCurrentUser) {
            const jwtToken = JSON.parse(atob(this.getCurrentUser.token.split('.')[1]));
            return jwtToken.Email;
        }
    }

    login(email: string, password: string): Observable<User> {
        return this.http.post<User>(`https://localhost:44367/api/user/login`, { email, password }, { withCredentials: true })
            .pipe(
                tap(data => { 
                    this.currentUserSubject.next(data);
                    this.startRefreshTokenTimer();
                    console.log("User logged in.");
                }),
            );
    }

    register(email: string, password: string): Observable<User> {
        return this.http.put<User>(`https://localhost:44367/api/user/register`, { email, password }, { withCredentials: true })
            .pipe(
                tap(data => {
                    console.log("User registered.");
                }),
            );
    }
    
    refreshToken(): Observable<User> {
        return this.http.put<User>(`https://localhost:44367/api/user/refreshToken`, {}, { withCredentials: true })
            .pipe(
                tap(data => {
                    this.currentUserSubject.next(data);
                    this.startRefreshTokenTimer();
                    console.log("Token refreshed.");
                })
            );
    }

    private startRefreshTokenTimer() {
        if(this.getCurrentUser) {
            const jwtToken = JSON.parse(atob(this.getCurrentUser.token.split('.')[1]));
            console.log(jwtToken);
            const expires = new Date(jwtToken.exp * 1000);
            const timeout = expires.getTime() - Date.now() - (5 * 1000);
            this.refreshTokenTimeout = setTimeout(() => this.refreshToken().subscribe(), timeout);
        }
    }

    private stopRefreshTokenTimer() {
        clearTimeout(this.refreshTokenTimeout);
    }
}