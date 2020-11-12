import { Component, OnInit } from '@angular/core';
import {Route, Router} from '@angular/router'
import { AuthService } from '../core/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private router:Router,private authService:AuthService) { }

  ngOnInit(): void {

  }
  ValidateRedirect():void  {
    // this.authservice.getToken("string","string").then(res=>);
  this.getToken();

  }
  getToken(){
    return this.authService.getToken("string","string").then()
     .catch(reason => {this.router.navigate(['/dashboard'])
     console.log(reason)});
 }
}
