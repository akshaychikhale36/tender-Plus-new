import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { Tender } from '../models/tender.model';
import { TenderService } from '../services/tender.service';
import { AlertPopupComponent } from '../shared/alert-popup/alert-popup.component';

@Component({
  selector: 'app-edit-bidding',
  templateUrl: './edit-bidding.component.html',
  styleUrls: ['./edit-bidding.component.css']
})
export class EditBiddingComponent implements OnInit {
  @ViewChild(AlertPopupComponent) alertPopupComponent;
  tender:Tender={};
  id: string;
  res: any;
  constructor(private router: Router, private tenderService: TenderService, private ngxService: NgxUiLoaderService) { }

  ngOnInit(): void {

    this.tender.bidding={}
    this.tender=history.state as Tender;
    this.id=this.getTokenStorage()
  }
  getTokenStorage(): string {
    return localStorage.getItem("id");
  }
  save() {
    this.tender.bidding.reporteeId= Number( this.id)
    this.ngxService.start();
    this.tenderService.UpdateTender(this.tender).subscribe(
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
          // this.tender.bidding = {}
          // this.tender = {}
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
