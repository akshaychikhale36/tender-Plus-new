import { Component, OnInit } from '@angular/core';
import { Tender } from '../models/tender.model';

@Component({
  selector: 'app-edit-bidding',
  templateUrl: './edit-bidding.component.html',
  styleUrls: ['./edit-bidding.component.css']
})
export class EditBiddingComponent implements OnInit {
  tender:Tender={};
  constructor() { }

  ngOnInit(): void {
    this.tender.Bidding={}
  }
  save() {

  }
}
