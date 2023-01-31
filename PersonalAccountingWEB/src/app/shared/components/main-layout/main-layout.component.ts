import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-main-layout',
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.css']
})
export class MainLayoutComponent {
  constructor(private jwtHelper: JwtHelperService,
              private router: Router){ }

  isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem("jwt");

    if(token && !this.jwtHelper.isTokenExpired(token)){
      return true;
    }

    return false;
  };

  logOut = () => {
    localStorage.removeItem("jwt");
    localStorage.removeItem("refreshToken");
    this.router.navigate(['/']);
  }
}
