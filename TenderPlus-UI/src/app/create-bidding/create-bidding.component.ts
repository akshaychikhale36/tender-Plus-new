import { Component, OnInit } from '@angular/core';
import { Tender } from '../models/tender.model';

@Component({
  selector: 'app-create-bidding',
  templateUrl: './create-bidding.component.html'
})
export class CreateBiddingComponent implements OnInit {
  tender:Tender={};

  constructor() { }

  ngOnInit(): void {
    this.tender.Bidding={}
  }
  save(){

  }
}
