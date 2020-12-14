import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { register } from '../models/register.model';
import { AlertPopupComponent } from '../shared/alert-popup/alert-popup.component';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  @ViewChild(AlertPopupComponent) alertPopupComponent;
  registerform: register={};
  constructor(private router: Router) { }

  ngOnInit(): void {
  }
  register() {
    if (!this.registerform.Name) {
      var title = 'Alert';
      var body = 'Please enter name';
      this.alertPopupComponent.alertMessage(title, body);
      return false
    } else
    if (!this.registerform.Email) {
      var title = 'Alert';
      var body = 'Please enter Email Id';
      this.alertPopupComponent.alertMessage(title, body);
      return false
    }else
    if (!this.registerform.Telephone) {
      var title = 'Alert';
      var body = 'Please enter Telephone Number';
      this.alertPopupComponent.alertMessage(title, body);
      return false
    }else
    if (!this.registerform.CompanyName) {
      var title = 'Alert';
      var body = 'Please enter Company name';
      this.alertPopupComponent.alertMessage(title, body);
      return false
    }else
    if (!this.registerform.License) {
      var title = 'Alert';
      var body = 'Please enter License Number ';
      this.alertPopupComponent.alertMessage(title, body);
      return false
    }else
    if (!this.registerform.PanId) {
      var title = 'Alert';
      var body = 'Please enter Pan Number';
      this.alertPopupComponent.alertMessage(title, body);
      return false
    }else
    if (!this.registerform.Aadhar) {
      var title = 'Alert';
      var body = 'Please enter Aadhar Number';
      this.alertPopupComponent.alertMessage(title, body);
      return false
    }

  }
}
