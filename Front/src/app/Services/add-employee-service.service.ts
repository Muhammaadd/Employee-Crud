import { IEmployee } from './../ViewModels/iemployee';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AddEmployeeServiceService {

  constructor(private httpClient:HttpClient) { }


  addEmployee(employee:IEmployee){
    return this.httpClient.post<any>('http://localhost:5203/api/Employee/addEmployee',employee);
  }
}

