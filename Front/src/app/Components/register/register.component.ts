import { SingUpServiceService } from './../../Services/sing-up-service.service';
import { ISignUp } from './../../ViewModels/isign-up';
import { AfterContentInit, AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit{
  userRegister:ISignUp={};
  agreeStatus!:boolean;
  errors!:any;
  constructor(private signUpService:SingUpServiceService,private router:Router) { }
  ngOnInit(): void {
  }
   register(){
  //   // if(
  //   //   this.userRegister.Name&&this.userRegister.Email&&
  //   //   this.userRegister.Password&&this.userRegister.ConfirmPassword&&
  //   //   this.userRegister.PhoneNumber&&this.agreeStatus===true)
      {
        this.signUpService.signUp(this.userRegister).subscribe({
          next: (data) => {
            this.router.navigate(['login']);
          },
          error:(error:any) => {
            this.errors=error.error;
            }}
            )
      }
  }
  setError(num:number){
    this.errors=null;
  }
}
