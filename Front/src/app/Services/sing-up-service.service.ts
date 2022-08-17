import { ISignUp } from './../ViewModels/isign-up';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SingUpServiceService {

  constructor(private httpClient:HttpClient) { }
  signUp(user:ISignUp){
  return this.httpClient.post<any>('http://localhost:5203/MeGz/Account/SignUp',user);
  }
}
