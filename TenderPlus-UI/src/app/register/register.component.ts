import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { AuthService } from '../core/auth.service';
import { login } from '../models/login.model';
import { register } from '../models/register.model';
import { AlertPopupComponent } from '../shared/alert-popup/alert-popup.component';
import { RegisterService } from './Service/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  @ViewChild(AlertPopupComponent) alertPopupComponent;
  loggedin: boolean;
  registerform: login = {};
  res: any;
  constructor(private router: Router, private regiService: RegisterService, private ngxService: NgxUiLoaderService, private authservice: AuthService) { }

  ngOnInit(): void {
    this.registerform.user = {};
    this.loggedin = this.authservice.isLoggedIn();
  }
  register() {
    if (this.loggedin) {
      this.registerform.Role = "Admin";
    } else {
      this.registerform.Role = "Normal";
    }
    if (!this.registerform.user.Name) {
      var title = 'Alert';
      var body = 'Please enter name';
      this.alertPopupComponent.alertMessage(title, body);
      return false
    } else
      if (!this.registerform.user.Email) {
        var title = 'Alert';
        var body = 'Please enter Email Id';
        this.alertPopupComponent.alertMessage(title, body);
        return false
      } else
        if (!this.registerform.user.Telephone) {
          var title = 'Alert';
          var body = 'Please enter Telephone Number';
          this.alertPopupComponent.alertMessage(title, body);
          return false
        } else
          if (!this.registerform.user.CompanyName) {
            var title = 'Alert';
            var body = 'Please enter Company name';
            this.alertPopupComponent.alertMessage(title, body);
            return false
          } else
            if (!this.registerform.user.License) {
              var title = 'Alert';
              var body = 'Please enter License Number ';
              this.alertPopupComponent.alertMessage(title, body);
              return false
            } else
              if (!this.registerform.user.PanId) {
                var title = 'Alert';
                var body = 'Please enter Pan Number';
                this.alertPopupComponent.alertMessage(title, body);
                return false
              } else
                if (!this.registerform.user.Aadhar) {
                  var title = 'Alert';
                  var body = 'Please enter Aadhar Number';
                  this.alertPopupComponent.alertMessage(title, body);
                  return false
                }
    if (!this.registerform.Password) {
      var title = 'Alert';
      var body = 'Please enter password';
      this.alertPopupComponent.alertMessage(title, body);
      return false
    }

    this.registerform.UserName = this.registerform.user.Name;



    this.ngxService.start();
    this.regiService.registerUser(this.registerform).subscribe(
      (res) => {

        this.res = res;
        this.ngxService.stop();
        if (!res) {
          var title = 'Alert';
          var body = 'Please register again';
          this.alertPopupComponent.alertMessage(title, body);
        }
        else {
          var title = 'Alert';
          var body = ' register Sucessfully';
          this.alertPopupComponent.alertMessage(title, body);
          this.registerform = {};
          this.registerform.user = {};
        }
      },
      (error) => {
        this.ngxService.stop();
        var title = 'Alert';
        var body = 'Please register again';
        this.alertPopupComponent.alertMessage(title, body);
        console.log(error);
      }
    )
  }
}
