import { RegisterViewModel } from './../../viewModel/user/registerViewModel';
import { AuthenticationService } from './../../services/authentication.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
@Component({
    selector: 'app-register-user',
    templateUrl: './register-user.component.html',
    styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {
    public registerForm: FormGroup;
    constructor(private _authService: AuthenticationService) { }
    ngOnInit(): void {
        this.registerForm = new FormGroup({
            email: new FormControl('', [Validators.required, Validators.email]),
            password: new FormControl('', [Validators.required]),
            confirm: new FormControl('')
        });
    }
    public validateControl = (controlName: string) => {
        return this.registerForm.controls[controlName].invalid && this.registerForm.controls[controlName].touched
    }
    public hasError = (controlName: string, errorName: string) => {
        return this.registerForm.controls[controlName].hasError(errorName)
    }
    public registerUser = (registerFormValue) => {
        const formValues = { ...registerFormValue };
        const user: RegisterViewModel = {
            email: formValues.email,
            password: formValues.password,
            confirmPassword: formValues.confirm
        };
        this._authService.registerUser("api/accounts/registration", user)
            .subscribe(_ => {
                console.log("Successful registration");
            },
                error => {
                    console.log(error.error.errors);
                })
    }
}