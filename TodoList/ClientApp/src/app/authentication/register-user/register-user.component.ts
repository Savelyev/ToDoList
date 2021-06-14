import { RegisterViewModel } from './../../viewModel/user/registerViewModel';
import { AuthenticationService } from './../../services/authentication.service';
import { PasswordConfirmationValidatorService } from './../../shared/custom-validators/password-confirmation-validator.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
    selector: 'app-register-user',
    templateUrl: './register-user.component.html',
    styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {
    public registerForm: FormGroup;
    public errorMessage: string = '';
    public showError: boolean;

    constructor(private _authService: AuthenticationService, private _passConfValidator: PasswordConfirmationValidatorService,
        private _router: Router) { }

    ngOnInit(): void {
        this.registerForm = new FormGroup({
            email: new FormControl('', [Validators.required, Validators.email]),
            password: new FormControl('', [Validators.required]),
            confirm: new FormControl('')
        });
        this.registerForm.get('confirm').setValidators([Validators.required,
            this._passConfValidator.validateConfirmPassword(this.registerForm.get('password'))]);
    }

    public validateControl = (controlName: string) => {
        return this.registerForm.controls[controlName].invalid && this.registerForm.controls[controlName].touched
    }

    public hasError = (controlName: string, errorName: string) => {
        return this.registerForm.controls[controlName].hasError(errorName)
    }

    public registerUser = (registerFormValue) => {
        this.showError = false;
        const formValues = { ...registerFormValue };
        const user: RegisterViewModel = {
            email: formValues.email,
            password: formValues.password,
            confirmPassword: formValues.confirm
        };
        this._authService.registerUser("api/accounts/registration", user)
            .subscribe(_ => {
                this._router.navigate(["/authentication/login"]);
            },
                error => {
                    this.errorMessage = error.errors.join('</br>');
                    this.showError = true;
                })
    }
}