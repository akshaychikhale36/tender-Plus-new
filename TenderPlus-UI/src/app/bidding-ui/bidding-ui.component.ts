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

  tender: Tender = {};
  res: any;
  userId: string;
  constructor(
    private router: Router,
    private tenderService: TenderService,
    private ngxService: NgxUiLoaderService,
  ) { }


  ngOnInit(): void {
    this.tender = history.state as Tender;
    this.userId=this.getTokenStorage()
    // this.countdown.begin();
  }
  getTokenStorage(): string {
    return localStorage.getItem("id");
  }
  GetBid() {
    this.tenderService.createTender(this.tender).subscribe(
      (res) => {
        this.ngxService.stop();
        this.res = res;
      },
      (error) => {
        this.ngxService.stop();
        console.log(error);
      }
    )
  }

  postBid() {
    this.tenderService.posttenderbid(this.tender.id,Number(this.userId),Number(this.tender.bidding.finalBid)).subscribe(
      (res) => {
        this.ngxService.stop();
        this.res = res;
      },
      (error) => {
        this.ngxService.stop();
        console.log(error);
      }
    )
  }
}
