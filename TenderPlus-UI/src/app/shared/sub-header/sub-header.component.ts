import { Component, OnInit } from '@angular/core';
import { Router, RouterEvent, RouterModule } from '@angular/router';
import { AuthService } from 'src/app/core/auth.service';
import { AuthResponse } from 'src/app/core/models/authRequest';
import { RegisterService } from 'src/app/register/Service/register.service';


@Component({
  selector: 'app-sub-header',
  templateUrl: './sub-header.component.html',
  styleUrls: ['./sub-header.component.css']
})
export class SubHeaderComponent implements OnInit {
  loggedin: boolean;
  isAdmin: boolean = false;
  username: string;

  constructor(private authservice: AuthService, private router: Router, private regservice: RegisterService) { }

  ngOnInit(): void {
    this.loggedin = this.authservice.isLoggedIn();
    this.username = this.getUserName();
    if(this.loggedin)
    this.setAdminFlag();
  }
  setAdminFlag() {
    this.regservice.getUserByID(this.username).subscribe(
      (res) => {

        if (res.role == "Admin") {
          this.isAdmin = true;
        }
      },
      (error) => {

        console.log(error);
      }
    )
  }

  getUserName(): string {
    return localStorage.getItem("username");
  }
  logout() {
    this.authservice.deleteToken();
    this.router.navigate(['/login']);
  }

}
