import { Component, OnInit, ViewChild } from '@angular/core';
import { Tender } from '../models/tender.model';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  @ViewChild('dataTable') table;
  dtOptions: DataTables.Settings = {};
  tender:Tender={};
  constructor() { }

  ngOnInit(): void {
    this.tender.Bidding={}
    this.dtOptions = {
      dom: '<"dataTableTop"fp>t<"dataTablebottom"p><"clear">',
      pageLength: 10,
      ordering: false,
      info: false,
      responsive: true,
      searching: true,
    };
  }
}
