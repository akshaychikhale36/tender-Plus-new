import { Route } from '@angular/compiler/src/core';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { NgxUiLoaderBlurredDirective } from 'ngx-ui-loader/lib/core/ngx-ui-loader-blurred.directive';
import { register, registerUsers } from '../models/register.model';
import { Tender } from '../models/tender.model';
import { TenderService } from '../services/tender.service';
import { AlertPopupComponent } from '../shared/alert-popup/alert-popup.component';

@Component({
  selector: 'app-view-bidding',
  templateUrl: './view-bidding.component.html',
  styleUrls: ['./view-bidding.component.css']
})
export class ViewBiddingComponent implements OnInit {
  @ViewChild(AlertPopupComponent) alertPopupComponent;
  tender: Tender = {};
  @ViewChild('dataTable') table;
  users: registerUsers;
  user: register = {};
  dtOptions: DataTables.Settings = {};
  constructor(private router: Router,private tenderService:TenderService,private ngxService:NgxUiLoaderService) { }

  ngOnInit(): void {
    this.tender.bidding = {}
    this.tender = history.state as Tender;
    this.dtOptions = {
      dom: '<"dataTableTop"fp>t<"dataTablebottom"p><"clear">',
      pageLength: 10,
      ordering: false,
      info: false,
      responsive: true,
      searching: true,
    };
    this.getRegisteredUsers()
    // this.populateUsers();
  }


  getRegisteredUsers(){
    this.ngxService.start();
    this.tenderService.GetRegisteredUsers(this.tender.id).subscribe(
      (res) => {
        this.ngxService.stop();
        this.users = res;

      },
      (error) => {
        this.ngxService.stop();
        var title = 'Alert';
        var body = 'Failed to Load List ';
        this.alertPopupComponent.alertMessage(title, body);
        console.log(error);
      }
    )

  }

  // populateUsers() {
  //   this.user.Aadhar='123'
  //   this.user.PanId='123'
  //   this.user.Name='askshay'
  //   this.user.Email='abc'
  //   this.users.push(this.user);
  //   this.users.push(this.user);
  // }
  Edit() {
    this.router.navigate(['/editbidding'], { state: this.tender })
  }
}
