import { Component } from '@angular/core';
import { LoginModel } from '../_interfaces/login.model';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { AuthenticatedResponse } from '../_interfaces/authenticated-response.model';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent {
    invalidLogin?: boolean;
    credentials: LoginModel = {
    username: '',
    password: ''
  };

  constructor(private router: Router, private http: HttpClient){

  }

  login = ( form: NgForm) => {
    if(form.valid) {
      this.http.post<AuthenticatedResponse>(
        "api/authentication/login",
        this.credentials,
        {
          headers: new HttpHeaders({ "Content-Type": "application/json" })
        }
      )
        .subscribe({
          next: (response: AuthenticatedResponse) =>{
            const token = response.accessToken;
            const refreshToken = response.refreshToken;
            localStorage.setItem("jwt", token);
            localStorage.setItem("refreshToken", refreshToken)
            this.invalidLogin = false;
            this.router.navigate(['/']);
          },
          error: (err: HttpErrorResponse) => this.invalidLogin = true
        })
    }
  }
}
