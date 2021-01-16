import { Component, OnInit, ViewChild } from '@angular/core';
import { dateInputsHaveChanged } from '@angular/material/datepicker/datepicker-input-base';
import { Router } from '@angular/router';
import { ready } from 'jquery';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { Tender } from '../models/tender.model';
import { TenderService } from '../services/tender.service';
import { AlertPopupComponent } from '../shared/alert-popup/alert-popup.component';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss', './dashboard.css']
})

export class DashboardComponent implements OnInit {
  count: number[];
  @ViewChild(AlertPopupComponent) alertPopupComponent;
  @ViewChild('dataTable') table;
  dtOptions: DataTables.Settings = {};
  tender: Tender[] = [];
  usertender: Tender[] = [];
  Progresstender: Tender[] = [];
  userId: string;
  assigntender: Tender[] = [];
  constructor(
    private router: Router,
    private tenderService: TenderService,
    private ngxService: NgxUiLoaderService
  ) { }

  ngOnInit(): void {
    this.count = [1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 8]
    this.userId = this.getTokenStorage()
    this.getuserregisters();
    this.getWorklist();
    this.getuserassign();
    this.getuserprogresstender();
  }

  getuserassign() {
    this.ngxService.start();
    this.tenderService.getuserassign(Number(this.userId)).subscribe(
      (res) => {
        this.ngxService.stop();
        this.assigntender = res;
        // this.assigntender=this.assigntender.filter(x=>!this.usertender.find(x1=>x1.id===x.id));
      },
      (error) => {
        this.ngxService.stop();
        // var title = 'Alert';
        // var body = 'Please create again';
        // this.alertPopupComponent.alertMessage(title, body);
        console.log(error);
      }
    )
  }

  getTokenStorage(): string {
    return localStorage.getItem("id");
  }

  getuserregisters() {
    this.ngxService.start();
    this.tenderService.getuserregisters(Number(this.userId)).subscribe(
      (res) => {
        this.ngxService.stop();
        this.usertender = res;

        this.usertender = this.usertender.filter(x => new Date(x.closeDate) > new Date());
      },
      (error) => {
        this.ngxService.stop();
        // var title = 'Alert';
        // var body = 'Please create again';
        // this.alertPopupComponent.alertMessage(title, body);
        console.log(error);
      }
    )

  }

  getuserprogresstender() {
    this.ngxService.start();
    this.tenderService.getuserprogresstender(Number(this.userId)).subscribe(
      (res) => {
        this.ngxService.stop();
        this.Progresstender = res;
        this.usertender = this.usertender.filter(x => new Date(x.closeDate) > new Date());
      },
      (error) => {
        this.ngxService.stop();
        // var title = 'Alert';
        // var body = 'Please create again';
        // this.alertPopupComponent.alertMessage(title, body);
        console.log(error);
      }
    )
  }

  getWorklist() {
    this.ngxService.start();
    this.tenderService.GetTenders().subscribe(
      (res) => {
        this.ngxService.stop();
        this.tender = res;
        this.tender = this.tender.filter(x => new Date(x.closeDate) > new Date());
        this.tender = this.tender.filter(x => !this.usertender.find(x1 => x1.id === x.id));
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

  openCity(cityName: any) {
    // Declare all variables
    var i, tabcontent, tablinks;

    // Get all elements with class="tabcontent" and hide them
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
      tabcontent[i].style.display = "none";
    }

    // Get all elements with class="tablinks" and remove the class "active"
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
      tablinks[i].className = tablinks[i].className.replace(" active", "");
    }

    // Show the current tab, and add an "active" class to the button that opened the tab
    document.getElementById(cityName).style.display = "block";
    // evt.currentTarget.className += " active";
  }
}
