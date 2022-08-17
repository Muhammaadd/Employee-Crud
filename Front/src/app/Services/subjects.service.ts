import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { IEmployeeDetails } from '../ViewModels/iemployee-details';

@Injectable({
  providedIn: 'root'
})
export class SubjectsService {
employeeDetailsSubject = new Subject<IEmployeeDetails>();
employeeeditform:any;
  constructor() { }
  setEmployeeToEditForm(employee:IEmployeeDetails){
    this.employeeDetailsSubject.next(employee);
    console.log("this is subject function and this employee of subject",this.employeeDetailsSubject);
  }
  getEmployeeFromDetials(){
    return this.employeeDetailsSubject.asObservable();
  }
  setee(employee:IEmployeeDetails){
    this.employeeeditform = employee;
  }
  getee(){
    return this.employeeeditform;
  }
}
