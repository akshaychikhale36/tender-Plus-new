import { NgZone } from '@angular/core';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { register } from '../models/register.model';
import { Tender } from '../models/tender.model';
import { ICustomWindow, WindowRefService } from './window-ref.service';

@Component({
  selector: 'app-view-tender',
  templateUrl: './view-tender.component.html',
  styleUrls: ['./view-tender.component.css']
})
export class ViewTenderComponent implements OnInit {
  private _window: ICustomWindow;
  public rzp: any;
  tender: Tender = {};
  @ViewChild('dataTable') table;
  dtOptions: DataTables.Settings = {};
  public options: any = {
    key: 'rzp_test_OqL3i9Rr9cpCk2', // add razorpay key here
    name: 'Tender Name',
    description: 'Fees',
    amount: 100, // razorpay takes amount in paisa
    prefill: {
      name: 'Tender Registration amout',
      email: '', // add your email id
    },
    notes: {},
    theme: {
      color: '#3880FF'
    },
    handler: this.paymentHandler.bind(this),
    modal: {
      ondismiss: (() => {
        this.zone.run(() => {
          // add current page routing if payment fails
        })
      })
    }
  };
  constructor(private router: Router,
    private zone: NgZone,
    private winRef: WindowRefService) {
    this._window = this.winRef.nativeWindow;
  }

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

  }

  register() {
    this.rzp = new this.winRef.nativeWindow['Razorpay'](this.options);
    this.rzp.open();
    // this.router.navigate(['/editbidding'], { state: this.tender })
  }
  paymentHandler(res: any) {
    this.zone.run(() => {
      // add API call here
    });
  }
}