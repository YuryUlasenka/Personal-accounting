import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticatedResponse } from '../_interfaces/authenticated-response.model';
import { LoginModel } from "../_interfaces/login.model";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
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
