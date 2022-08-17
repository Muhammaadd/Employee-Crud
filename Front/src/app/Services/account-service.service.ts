import { ILogin } from './../ViewModels/ilogin';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountServiceService {
  constructor(private httpClient:HttpClient) {
  }
  checkEmailAndPassword(userData:ILogin){
    return this.httpClient.post<any>('http://localhost:5203/MeGz/Account/Login',userData);
  }
  saveUserTokenToCookies(token:string){
  }
  getUserToken():string{
      let name = 'token' + "=";
      let decodedCookie = decodeURIComponent(document.cookie);
      let ca = decodedCookie.split(';');
      for(let i = 0; i <ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
          c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
          return c.substring(name.length, c.length);
        }
  }
      return "";
    }
  setUserToken(token:string){
    document.cookie = `token=${token}`;
  }
  getAuthenticationStatus():boolean{
    if(this.getUserToken())
      return true;
    else{
      return false;
    }
  }
}
