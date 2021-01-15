import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { CountdownComponent } from 'ngx-countdown';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { Tender } from '../models/tender.model';
import { TenderService } from '../services/tender.service';
import { AlertPopupComponent } from '../shared/alert-popup/alert-popup.component';

@Component({
  selector: 'app-bidding-ui',
  templateUrl: './bidding-ui.component.html',
  styleUrls: ['./bidding-ui.component.css']
})
export class BiddingUiComponent implements OnInit {
  @ViewChild(AlertPopupComponent) alertPopupComponent;
  // @ViewChild('cd', { static: false }) private countdown: CountdownComponent;
  tempBid:number =0;
  tender: Tender = {};
  res: any;
  userId: string;
  sec: number;
  constructor(
    private router: Router,
    private tenderService: TenderService,
    private ngxService: NgxUiLoaderService,
  ) { }


  ngOnInit(): void {
    this.tender = history.state as Tender;
    this.userId = this.getTokenStorage()
    this.GetBid();

this.sec=86400-this.getSecondsToday();
    // this.countdown.begin();
  }
  getTokenStorage(): string {
    return localStorage.getItem("id");
  }

  getSecondsToday() {
    var d = new Date();
    return d.getHours() * 3600 + d.getMinutes() * 60 + d.getSeconds();
  }
  GetBid() {
    this.tenderService.gettenderbid(Number(this.tender.id)).subscribe(
      (res) => {
        this.ngxService.stop();
        this.tender.bidding.finalBid = res;
      },
      (error) => {
        this.ngxService.stop();
        console.log(error);
      }
    )
  }

  postBid() {
    if(this.tender.bidding.finalBid!=undefined && Number(this.tender.bidding.finalBid) > this.tempBid) {
      var title = 'Alert';
      var body = 'Please Valid Bid';
      this.alertPopupComponent.alertMessage(title, body);
      return false;
    }
    this.tender.bidding.finalBid=this.tempBid.toString();
    this.ngxService.start();
    this.tenderService.posttenderbid(this.tender.id, Number(this.userId), Number(this.tender.bidding.finalBid)).subscribe(
      (res) => {
        this.ngxService.stop();
        this.res = res;
        this.GetBid();
      },
      (error) => {
        this.ngxService.stop();
        console.log(error);
      }
    )
  }
}
