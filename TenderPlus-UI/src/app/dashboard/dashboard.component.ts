import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
count:number[];
  constructor() { }

  ngOnInit(): void {
    this.count=[1,2,3]
  }

}
