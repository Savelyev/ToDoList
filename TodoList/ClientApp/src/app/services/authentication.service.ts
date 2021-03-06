import { RegisterViewModel } from './../viewModel/user/registerViewModel';
import { LoginViewModel } from './../viewModel/user/logingViewModel';
import { RegisterResponseViewModel } from './../viewModel/response/registerResponseViewModel';
import { AuthResponseViewModel } from './../viewModel/response/authResponseViewModel';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {

    private _authChangeSub = new Subject<boolean>()
    public authChanged = this._authChangeSub.asObservable();

    constructor(private http: HttpClient, private _jwtHelper: JwtHelperService) { }

    public registerUser = (route: string, body: RegisterViewModel) => {
        return this.http.post<RegisterResponseViewModel>(route, body);
    }

    public loginUser = (route: string, body: LoginViewModel) => {
        return this.http.post<AuthResponseViewModel>(route, body);
    }

    public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
        this._authChangeSub.next(isAuthenticated);
    }

    public logout = () => {
        localStorage.removeItem("token");
        this.sendAuthStateChangeNotification(false);
    }

    public isUserAuthenticated = (): boolean => {
        const token = localStorage.getItem("token");

        return token && !this._jwtHelper.isTokenExpired(token);
    }
}