import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './core/auth.guard';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';



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
    path: '**',
    component: LoginComponent
  },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
