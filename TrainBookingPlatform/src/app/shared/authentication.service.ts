import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { BehaviorSubject, Observable, tap } from "rxjs";
import { Response } from "./response.model";
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

    public getCurrentUserEmail(token: string) {
        const jwtToken = JSON.parse(atob(token.split('.')[1]));
        return jwtToken.Email;
    }

    public getCurrentUserRole(token: string) {
        const jwtToken = JSON.parse(atob(token.split('.')[1]));
        return jwtToken.Roles;
    }

    login(email: string, password: string): Observable<Response> {
        return this.http.post<Response>(`https://localhost:44367/api/user/login`, { email, password }, { withCredentials: true})
            .pipe(
                tap(data => {
                    if(data.value != null){
                        var user = <User> data.value;
                        user.role = this.getCurrentUserRole(user.token);
                        user.email = this.getCurrentUserEmail(user.token);
                        this.currentUserSubject.next(user);
                        this.startRefreshTokenTimer();
                    }
                }),
            );
    }

    logout() {
        return this.http.post(`https://localhost:44367/api/user/revokeToken`, {}, { withCredentials: true })
            .pipe(
                tap(data => {
                    this.currentUserSubject.next(null);
                    this.stopRefreshTokenTimer();
                    console.log("User logged out.");
                }),
            );
    }

    register(email: string, password: string): Observable<Response> {
        return this.http.put<Response>(`https://localhost:44367/api/user/register`, { email, password }, { withCredentials: true })
            .pipe(
                tap(data => {
                    console.log("User registered.");
                }),
            );
    }

    refreshToken(): Observable<Response> {
        return this.http.put<Response>(`https://localhost:44367/api/user/refreshToken`, {}, { withCredentials: true })
            .pipe(
                tap(data => {
                    if(data.value != null){
                        var user = <User> data.value;
                        user.role = this.getCurrentUserRole(user.token);
                        user.email = this.getCurrentUserEmail(user.token);
                        this.currentUserSubject.next(user);
                        this.startRefreshTokenTimer();
                    }
                })
            );
    }

    private startRefreshTokenTimer() {
        if (this.getCurrentUser) {
            const jwtToken = JSON.parse(atob(this.getCurrentUser.token.split('.')[1]));
            const expires = new Date(jwtToken.exp * 1000);
            const timeout = expires.getTime() - Date.now() - (5 * 1000);
            this.refreshTokenTimeout = setTimeout(() => this.refreshToken().subscribe(), timeout);
        }
    }

    private stopRefreshTokenTimer() {
        clearTimeout(this.refreshTokenTimeout);
    }
}