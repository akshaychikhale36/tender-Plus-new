import { registerLocaleData } from '@angular/common';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AboutUsComponent } from './about-us/about-us.component';
import { AdminComponent } from './admin/admin.component';
import { BiddingUiComponent } from './bidding-ui/bidding-ui.component';
import { AuthGuard } from './core/auth.guard';
import { CreateBiddingComponent } from './create-bidding/create-bidding.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EditBiddingComponent } from './edit-bidding/edit-bidding.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ViewBiddingComponent } from './view-bidding/view-bidding.component';
import { ViewTenderComponent } from './view-tender/view-tender.component';
import { YourTenderComponent } from './your-tender/your-tender.component';



const routes: Routes = [

  {
    path: 'login',
    component: LoginComponent
  },
  {
    path:'dashboard',
    component: DashboardComponent,canActivate: [AuthGuard]
  },
  {
    path:'home',
    component: HomeComponent
  },
  {
    path:'register',
    component: RegisterComponent
  },
  {
    path:'about-us',
    component: AboutUsComponent
  },
  {
    path:'createbidding',
    component: CreateBiddingComponent
  },
  {
    path:'admin',
    component: AdminComponent
  },
  {
    path:'viewbidding',
    component: ViewBiddingComponent
  },
  {
    path:'editbidding',
    component: EditBiddingComponent
  },
  {
    path:'viewtender',
    component: ViewTenderComponent
  },
  {
    path:'makebidding',
    component: BiddingUiComponent
  },
  {
    path:'yourtender',
    component: YourTenderComponent
  },
  {
    path: '**',
    component: HomeComponent
  },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
