import { Route } from '@angular/compiler/src/core';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { NgxUiLoaderBlurredDirective } from 'ngx-ui-loader/lib/core/ngx-ui-loader-blurred.directive';
import { Tender } from '../models/tender.model';
import { TenderService } from '../services/tender.service';
import { AlertPopupComponent } from '../shared/alert-popup/alert-popup.component';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  @ViewChild(AlertPopupComponent) alertPopupComponent;
  @ViewChild('dataTable') table;
  dtOptions: DataTables.Settings = {};
  tender: Tender[] = [];
  tenderpolu: Tender = {};

  worklist: any;
  res: any;
  // tender:Tender={};
  constructor(
    private router: Router,
    private tenderService:TenderService,
    private ngxService:NgxUiLoaderService
  ) { }

  ngOnInit(): void {
    this.tenderpolu.bidding = {}
    this.dtOptions = {
      dom: '<"dataTableTop"fp>t<"dataTablebottom"p><"clear">',
      pageLength: 10,
      ordering: false,
      info: false,
      responsive: true,
      searching: true,
    };
    this.getWorklist()
    // this.populateData();
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
  populateData() {
    // this.tenderpolu.Title = "test"
    // this.tenderpolu.Location = "test"
    // this.tenderpolu.State = "test"
    // this.tenderpolu.District = "test"
    this.tenderpolu.bidding.inititalBid = "5000"
    this.tender.push(this.tenderpolu)

  }
  redirectView(tender: Tender) {
    this.router.navigate(['/viewbidding'],{state:tender});
  }
  redirectEdit(tender: Tender) {
    this.router.navigate(['/editbidding'],{state:tender});
  }
  redirectDelete(tender: Tender) {
    this.ngxService.start();
    this.tenderService.DeleteTender(tender).subscribe(
      (res) => {
        this.ngxService.stop();
        this.res = res;
        if (!res) {
          var title = 'Alert';
          var body = 'Delete Unsuccessful';
          this.alertPopupComponent.alertMessage(title, body);
        }
        else {
          var index = this.tender.indexOf(tender);
          this.tender.splice(index, 1);
          var title = 'Alert';
          var body = ' Deleted Sucessfully';
          this.alertPopupComponent.alertMessage(title, body);
        }
      },
      (error) => {
        this.ngxService.stop();
        var title = 'Alert';
        var body = 'Please create again';
        this.alertPopupComponent.alertMessage(title, body);
        console.log(error);
      }
    )}

}
