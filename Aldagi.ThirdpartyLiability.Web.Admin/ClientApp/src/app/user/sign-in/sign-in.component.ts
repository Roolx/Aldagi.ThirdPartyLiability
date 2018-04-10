import { Component, OnInit, Inject } from '@angular/core';
import { UserService } from '../../shared/services/user.service';
import { HttpErrorResponse, HttpClient} from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  isLoginError: boolean = false;
  baseUrl: string;

  constructor(private userService: UserService, private router: Router, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
  }

  OnSubmit(userName, password) {
    this.userService.userAuthentication(userName, password).subscribe((data: any) => {
      localStorage.setItem("access_token",data.access_token);
      this.router.navigate(['/home']);
    }, (error => {
      this.isLoginError = true;
    }));
  }

}
