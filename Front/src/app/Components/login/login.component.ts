import { AccountServiceService } from './../../Services/account-service.service';
import { ILogin } from './../../ViewModels/ilogin';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  userLogin:ILogin={rememberMe:false};
  Checkinfo!:boolean;
  errors!:any;
  constructor(private accountService:AccountServiceService,private router:Router) {

  }

  ngOnInit(): void {

  }
  login():void{
    if(this.userLogin.email===""||this.userLogin.password===""){
      this.router.navigate(['Login']);
    }
    else{
      this.accountService.checkEmailAndPassword(this.userLogin).subscribe({
        next: (data) => {
          if(data.token)
          {
            this.accountService.setUserToken(data.token);
            this.router.navigate(['home']);
          }
        },
        error:(error:any) => {
          this.errors=error.error;
          console.log(error.error);
          }}
          )
    }
  }
  setErrors(){
    this.errors = null;
  }
}
