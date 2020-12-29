import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Tender } from '../models/tender.model';

@Component({
  selector: 'app-view-bidding',
  templateUrl: './view-bidding.component.html',
  styleUrls: ['./view-bidding.component.css']
})
export class ViewBiddingComponent implements OnInit {
  tender:Tender={};
  constructor(private router:Router) { }

  ngOnInit(): void {
    this.tender.Bidding={}
  }
  Edit(){
    this.router.navigate(['/editbidding'],{state:this.tender})
  }
}
