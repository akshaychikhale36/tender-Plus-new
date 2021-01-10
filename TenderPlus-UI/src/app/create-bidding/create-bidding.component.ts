import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { AuthService } from '../core/auth.service';
import { Tender } from '../models/tender.model';
import { RegisterService } from '../register/Service/register.service';
import { TenderService } from '../services/tender.service';
import { AlertPopupComponent } from '../shared/alert-popup/alert-popup.component';

@Component({
  selector: 'app-create-bidding',
  templateUrl: './create-bidding.component.html'
})
export class CreateBiddingComponent implements OnInit {
  tender: Tender = {};
  @ViewChild(AlertPopupComponent) alertPopupComponent;
  res: any;
  id: string;
  constructor(private router: Router, private tenderService: TenderService, private ngxService: NgxUiLoaderService) { }

  ngOnInit(): void {
    this.tender.Bidding = {}
    this.id=this.getTokenStorage()
  }
  getTokenStorage(): string {
    return localStorage.getItem("id");
  }
  save() {
    // var title = 'Alert';
    // var body = 'Created Sucessfully';
    // this.alertPopupComponent.alertMessage(title, body);
    this.tender.Bidding.ReporteeId= Number( this.id)
    this.ngxService.start();
    this.tenderService.createTender(this.tender).subscribe(
      (res) => {
        this.ngxService.stop();
        this.res = res;
        if (!res) {
          var title = 'Alert';
          var body = 'Please create again';
          this.alertPopupComponent.alertMessage(title, body);
        }
        else {
          var title = 'Alert';
          var body = ' created Sucessfully';
          this.alertPopupComponent.alertMessage(title, body);
          this.tender.Bidding = {}
          this.tender = {}
        }
      },
      (error) => {
        this.ngxService.stop();
        var title = 'Alert';
        var body = 'Please create again';
        this.alertPopupComponent.alertMessage(title, body);
        console.log(error);
      }
    )
  }
}

