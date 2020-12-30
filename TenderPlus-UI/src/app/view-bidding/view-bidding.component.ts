import { Route } from '@angular/compiler/src/core';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { register } from '../models/register.model';
import { Tender } from '../models/tender.model';

@Component({
  selector: 'app-view-bidding',
  templateUrl: './view-bidding.component.html',
  styleUrls: ['./view-bidding.component.css']
})
export class ViewBiddingComponent implements OnInit {
  tender: Tender = {};
  @ViewChild('dataTable') table;
  users: register[] = [];
  user: register = {};
  dtOptions: DataTables.Settings = {};
  constructor(private router: Router) { }

  ngOnInit(): void {
    this.tender.Bidding = {}
    this.tender = history.state as Tender;
    this.dtOptions = {
      dom: '<"dataTableTop"fp>t<"dataTablebottom"p><"clear">',
      pageLength: 10,
      ordering: false,
      info: false,
      responsive: true,
      searching: true,
    };
    this.populateUsers();
  }
  populateUsers() {
    this.user.Aadhar='123'
    this.user.PanId='123'
    this.user.Name='askshay'
    this.user.Email='abc'
    this.users.push(this.user);
    this.users.push(this.user);
  }
  Edit() {
    this.router.navigate(['/editbidding'], { state: this.tender })
  }
}
