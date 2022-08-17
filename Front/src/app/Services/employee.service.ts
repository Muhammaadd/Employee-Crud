import { IEmployeeDetails } from './../ViewModels/iemployee-details';
import { IEmployeeView } from './../ViewModels/iemployee-view';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { IEmployee } from '../ViewModels/iemployee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private httpClient:HttpClient,private router:Router) { }
  getAllEmployees(){
    return this.httpClient.get<IEmployeeView[]>('http://localhost:5203/api/Employee');
  }
  getById(id:number){
    return this.httpClient.get<IEmployeeDetails>(`http://localhost:5203/api/Employee/${id}`);
  }
  deleteById(id:number){
    console.log(id);
    this.httpClient.delete(`http://localhost:5203/api/Employee/Delete/${id}`).subscribe(
      {
        complete:()=>{
          this.router.navigate(['/employee']);
        }
      }
    );
  }
  update(employee:IEmployeeDetails){
    return this.httpClient.put(`http://localhost:5203/api/Employee/Update/${employee.id}`,employee);
  }
}
