import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router'
import { AuthService } from '../core/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  UserId: string;
  Password: string;
  token: Promise<any>;
  res: any;
  constructor(private router: Router, private authService: AuthService) { }

  ngOnInit(): void {
    this.Password = '';
    this.UserId = '';
  }
  ValidateRedirect(): void {
    // this.authservice.getToken("string","string").then(res=>);
    this.getToken();
console.log(this.res);
    this.router.navigate(['/dashboard']);
  }
  getToken() {
    return this.authService.getToken(this.UserId, this.Password).then((res)=>this.res);

  }
}
