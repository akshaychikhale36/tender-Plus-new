import { Component, OnInit, ViewChild } from '@angular/core';
import { Route, Router } from '@angular/router'
import { AuthService } from '../core/auth.service';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { AlertPopupComponent } from '../shared/alert-popup/alert-popup.component';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  @ViewChild(AlertPopupComponent) alertPopupComponent;
  UserId: string;
  Password: string;
  token: Promise<any>;
  res: any;
  constructor(private router: Router, private authService: AuthService,private ngxService: NgxUiLoaderService) { }

  ngOnInit(): void {
    this.Password = '';
    this.UserId = '';
  }
  ValidateRedirect(): void {
    // this.authservice.getToken("string","string").then(res=>);
     this.getToken();
    console.log(this.token);

  }
  getToken() {
    this.ngxService.start();
    this.authService.getToken(this.UserId, this.Password).subscribe(
      (res) =>
      {
        this.res=res;
        this.ngxService.stop();
        this.authService.mapToken(res);
        if(res.role!="Admin")
        this.router.navigate(['/dashboard']);
        else
        this.router.navigate(['/admin']);
      },
      (error) => {
        this.ngxService.stop();
        var title = 'Alert';
        var body = 'Please Login again';
        this.alertPopupComponent.alertMessage(title, body);
        console.log(error);
      }
    )
  }
}

