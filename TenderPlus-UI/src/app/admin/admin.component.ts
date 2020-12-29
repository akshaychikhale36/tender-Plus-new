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
  tender: Tender[] = [];
  tenderpolu:Tender={};
  // tender:Tender={};
  constructor() { }

  ngOnInit(): void {
    this.tenderpolu.Bidding={}
    this.dtOptions = {
      dom: '<"dataTableTop"fp>t<"dataTablebottom"p><"clear">',
      pageLength: 10,
      ordering: false,
      info: false,
      responsive: true,
      searching: true,
    };
    this.populateData();
  }
  populateData(){
this.tenderpolu.Title="test"
this.tenderpolu.Location="test"
this.tenderpolu.State="test"
this.tenderpolu.District="test"
this.tenderpolu.Bidding.InititalBid="5000"
this.tender.push(this.tenderpolu)

  }
  redirectView(tender:Tender){

  }
  redirectEdit(tender:Tender){

  }
  redirectDelete(tender:Tender){

  }
}
