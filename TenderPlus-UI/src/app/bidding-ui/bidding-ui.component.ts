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
  constructor(
    private router: Router,
    private tenderService:TenderService,
    private ngxService:NgxUiLoaderService,
  ) { }


  ngOnInit(): void {
    this.tender = history.state as Tender;
    // this.countdown.begin();
  }

}
