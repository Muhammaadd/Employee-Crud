import { IDepartment } from './../../ViewModels/idepartment';
import { Router } from '@angular/router';
import { IEmployee } from './../../ViewModels/iemployee';
import { Component, OnInit } from '@angular/core';
import { AddEmployeeServiceService } from 'src/app/Services/add-employee-service.service';
import { DeparmentService } from 'src/app/Services/deparment.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {
  employee:IEmployee={
    Date:new Date(),
    CheckIn:"",
    CheckOut:"",
    HireDate:new Date(),
  };
  departmentsList!:IDepartment[];
  errorsList:any;
  CurrentDate:Date = new Date();
  hireDateStatus:boolean=false;
  birthDateStatus:boolean=false;
  startTimeStatus:boolean=false;
  endTimeStatus:boolean=false;
  genderStatus:boolean=false;
  constructor(private employeeService:AddEmployeeServiceService,private router:Router,private departmentService:DeparmentService) {

  }
  ngOnInit(): void {
    this.departmentService.getAllDepartments().subscribe({
      next: data =>{
        this.departmentsList = data;
      },
      error: error =>{
        console.log(error);

      }
    });
  }
  addEmployee(){
    if(this.employee.Date>=this.employee.HireDate||this.employee.Date>this.CurrentDate)
      this.birthDateStatus=true;
    else
      this.birthDateStatus=false;
    if(this.employee.Gender==='0')
      this.genderStatus=true;
    else
      this.genderStatus=false;
    if(this.employee.HireDate<this.employee.Date||this.employee.HireDate>this.CurrentDate)
      this.hireDateStatus=true;
    else
      this.hireDateStatus=false;
    if(this.employee.CheckIn >= this.employee.CheckOut)
      this.startTimeStatus=true;
    else
      this.startTimeStatus=false;
    if(this.employee.CheckOut <= this.employee.CheckIn)
      this.endTimeStatus=true;
    else
      this.endTimeStatus=false;
    if(!this.birthDateStatus&&!this.genderStatus&&!this.hireDateStatus&&!this.startTimeStatus&&!this.endTimeStatus)
    {
      console.log("inside if ");

      this.employeeService.addEmployee(this.employee).subscribe(
        {
          next: (data) => {
            this.router.navigate(['employee']);
          },
          error:(error:any) => {
            console.log(error);
            this.errorsList=error.error.errors;
            }}
      )
    }
  }
}
