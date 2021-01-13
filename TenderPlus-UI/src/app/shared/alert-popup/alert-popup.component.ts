import { Component, Input, OnInit } from '@angular/core';

declare var $;

@Component({
  selector: 'app-alert-popup',
  templateUrl: './alert-popup.component.html',
})

export class AlertPopupComponent implements OnInit {
  @Input() title: string;
  @Input() body: string;

  constructor() { }

  ngOnInit(): void { }

  alertMessage(title: string, body: string) {
    var title = title;
    var body = body;
    $('#alertPopup .modal-title').html(title);
    $('#alertPopup .modal-body').html(body);
    $('#alertPopup').modal('show');
  }

  dismiss(): void {
    $('#alertPopup').modal('hide');
  }
}
