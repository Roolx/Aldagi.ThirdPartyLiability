import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../shared/services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  @Input()
  isInitialPage: boolean;
  
  isExpanded = false;

  constructor(private router: Router, private authService: AuthService) { }

  ngOnInit() {
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  logOut(){
    this.authService.logout();
  }
}
