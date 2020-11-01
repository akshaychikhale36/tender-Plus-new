import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgxPopper } from 'angular-popper';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppFooterComponent } from './shared/app-footer/app-footer.component';
import { AppHeaderComponent } from './shared/app-header/app-header.component';
import { SubHeaderComponent } from './shared/sub-header/sub-header.component';
import { MDBBootstrapModule,NavbarModule, WavesModule, ButtonsModule  } from 'angular-bootstrap-md';
import {RouterModule, Routes} from '@angular/router'


@NgModule({
  declarations: [
    AppComponent,
    AppHeaderComponent,
    AppFooterComponent,
    SubHeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgxPopper,
    MDBBootstrapModule.forRoot(),
    NavbarModule,
    WavesModule,
    ButtonsModule,
    RouterModule
  ],
  providers: [NavbarModule,
    WavesModule,
    ButtonsModule,
    RouterModule],
  bootstrap: [AppComponent],

})
export class AppModule { }
