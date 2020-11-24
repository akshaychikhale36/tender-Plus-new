import { Component, OnInit } from '@angular/core';
import { Router, RouterEvent, RouterModule } from '@angular/router';
import { AuthService } from 'src/app/core/auth.service';
import { AuthResponse } from 'src/app/core/models/authRequest';


@Component({
  selector: 'app-sub-header',
  templateUrl: './sub-header.component.html',
  styleUrls: ['./sub-header.component.css']
})
export class SubHeaderComponent implements OnInit {
loggedin:boolean;
  constructor(private authservice:AuthService, private router:Router) { }

  ngOnInit(): void {
    this.loggedin =this.authservice.isLoggedIn();
  }
  logout(){
    this.authservice.deleteToken();
    this.router.navigate(['/login']);
  }

}
