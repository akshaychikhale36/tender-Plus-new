import { registerLocaleData } from '@angular/common';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { AuthGuard } from './core/auth.guard';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';



const routes: Routes = [

  {
    path: '\login',
    component: LoginComponent
  },
  {
    path:'\dashboard',
    component: DashboardComponent,canActivate: [AuthGuard]
  },
  {
    path:'\home',
    component: HomeComponent
  },
  {
    path:'register',
    component: RegisterComponent
  },
  {
    path: '**',
    component: LoginComponent
  },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
