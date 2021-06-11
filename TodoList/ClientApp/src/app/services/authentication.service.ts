import { RegisterViewModel } from './../viewModel/user/registerViewModel';
import { RegisterResponseViewModel } from './../viewModel/response/registerResponseViewModel';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {
    constructor(private http: HttpClient) { }
    public registerUser = (route: string, body: RegisterViewModel) => {
        return this.http.post<RegisterResponseViewModel>(route, body);
    }
}