import { NgZone } from '@angular/core';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { register, registerUsers } from '../models/register.model';
import { Tender } from '../models/tender.model';
import { TenderService } from '../services/tender.service';
import { AlertPopupComponent } from '../shared/alert-popup/alert-popup.component';
import { PaymentService } from './payment.service';
import { ICustomWindow, WindowRefService } from './window-ref.service';

@Component({
  selector: 'app-view-tender',
  templateUrl: './view-tender.component.html',
  styleUrls: ['./view-tender.component.css']
})
export class ViewTenderComponent implements OnInit {
  @ViewChild(AlertPopupComponent) alertPopupComponent;
  private _window: ICustomWindow;
  public rzp: any;
  tender: Tender = {};
  paymentDone:boolean =false;
  @ViewChild('dataTable') table;
  dtOptions: DataTables.Settings = {};
  public options: any = {
    phone:'',
    key: 'rzp_test_fcCzFVhnxp0Dqj', // add razorpay key here
    name: 'Tender Name',
    description: 'Fees',
    amount: 10000, // razorpay takes amount in paisa
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
  userId: string;
  request:registerUsers={};

  constructor(private router: Router,
    private zone: NgZone,
    private winRef: WindowRefService,
    private payment:PaymentService,
    private tenderService:TenderService,
    private ngxService: NgxUiLoaderService) {
    this._window = this.winRef.nativeWindow;
  }

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
    this.userId=this.getTokenStorage()
  }
  getTokenStorage(): string {
    return localStorage.getItem("id");
  }
  register() {
    this.options.phone=this.userId;
    this.rzp = new this.winRef.nativeWindow['Razorpay'](this.options);
    this.rzp.open();
    // this.router.navigate(['/editbidding'], { state: this.tender })
  }
  paymentHandler(res: any) {
    this.zone.run(() => {
      this.payment.makepayement(this.options).subscribe(
        (res) =>
        {
          this.paymentDone=true;
          var title = 'Alert';
          var body = 'Payment Sucessful';
          this.alertPopupComponent.alertMessage(title, body);
          this.request.tenderId=this.tender.id
          this.request.userId=Number(this.userId)
          this.ngxService.start();

          this.tenderService.CreateTenderUsers(this.request).subscribe(
            res=>
            {
              this.ngxService.start();
                if(res){
                  var title = 'Alert';
                  var body = 'Registered Sucessfully';
                  this.alertPopupComponent.alertMessage(title, body);
                }
                else{
                  var title = 'Alert';
                  var body = 'Failed to Register, Refund is in Progress';
                  this.alertPopupComponent.alertMessage(title, body);
                }
            },
            (error) => {
              this.ngxService.stop();
              var title = 'Alert';
              var body = 'Failed to Register, Refund is in Progress';
              this.alertPopupComponent.alertMessage(title, body);
              console.log(error);
            }
          )

        },
        (error) => {

          console.log(error);
        }
      )
    });
  }
}
