import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { Tender } from '../models/tender.model';
import { TenderService } from '../services/tender.service';
import { AlertPopupComponent } from '../shared/alert-popup/alert-popup.component';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
count:number[];
@ViewChild(AlertPopupComponent) alertPopupComponent;
@ViewChild('dataTable') table;
dtOptions: DataTables.Settings = {};
tender: Tender[] = [];
constructor(
  private router: Router,
  private tenderService:TenderService,
  private ngxService:NgxUiLoaderService
) { }

  ngOnInit(): void {
    this.count=[1,2,3,4,5,6,7,8,9,8,8]
    this.getWorklist();
  }
  getWorklist() {
    this.ngxService.start();
    this.tenderService.GetTenders().subscribe(
      (res) => {
        this.ngxService.stop();
        this.tender = res;
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
