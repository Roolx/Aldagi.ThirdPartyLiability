import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { GeneralService } from './shared/services/general.service';
import { AuthService } from './shared/services/auth.service';
import {  } from "angular2-materialize";
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  liabilities: any;

  public isInitialPage: boolean;
  public isLoginPage: boolean;
  constructor(private router: Router, private generalService: GeneralService, private authService: AuthService) {

    

  }

  ngOnInit() {

    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.isInitialPage = this.router.isActive('/home', true);
        this.isLoginPage =  this.router.isActive('/login',true);
      }
    });


  }

  Logout() {
    this.authService.logout();
  }

}
