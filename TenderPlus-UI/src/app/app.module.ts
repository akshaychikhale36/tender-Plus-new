import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgxPopper } from 'angular-popper';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppFooterComponent } from './shared/app-footer/app-footer.component';
import { AppHeaderComponent } from './shared/app-header/app-header.component';
import { SubHeaderComponent } from './shared/sub-header/sub-header.component';
import { MDBBootstrapModule,NavbarModule, WavesModule, ButtonsModule  } from 'angular-bootstrap-md';
import { RouterModule} from '@angular/router'
import { AuthGuard } from './core/auth.guard';
import { TokenInterceptorService } from './core/Interceptor/TokenInterceptorService';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthService } from './core/auth.service';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { A11yModule } from '@angular/cdk/a11y';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { AdminComponent } from './admin/admin.component';
import { RegisterComponent } from './register/register.component';


@NgModule({
  declarations: [
    AppComponent,
    AppHeaderComponent,
    AppFooterComponent,
    SubHeaderComponent,
    LoginComponent,

    DashboardComponent,
    HomeComponent,
    AdminComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    FormsModule,
     HttpClientModule,
	  A11yModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgxPopper,
    MDBBootstrapModule.forRoot(),
    NavbarModule,
    WavesModule,
    ButtonsModule,
    RouterModule
  ],
  providers: [
    AuthService,
    AuthGuard,
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptorService, multi: true }],
  bootstrap: [AppComponent],

})
export class AppModule { }
