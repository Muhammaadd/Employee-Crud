import { SubjectsService } from './../../Services/subjects.service';
import { EmployeeService } from 'src/app/Services/employee.service';
import { DeparmentService } from 'src/app/Services/deparment.service';
import { Component, ElementRef, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AddEmployeeServiceService } from 'src/app/Services/add-employee-service.service';
import { IEmployee } from 'src/app/ViewModels/iemployee';
import { IDepartment } from 'src/app/ViewModels/idepartment';
import { IEmployeeDetails } from 'src/app/ViewModels/iemployee-details';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent implements OnInit {
  employee:IEmployeeDetails={
    date:new Date(),
    checkIn:"",
    checkOut:"",
    hiredate:new Date(),
  };
  departmentsList!:IDepartment[];
  errorsList:any;
  CurrentDate:Date = new Date();
  hireDateStatus:boolean=false;
  birthDateStatus:boolean=false;
  startTimeStatus:boolean=false;
  endTimeStatus:boolean=false;
  genderStatus:boolean=false;
  constructor(private subjectService:SubjectsService,private employeeService:EmployeeService,private router:Router,private departmentService:DeparmentService) { }
  ngOnInit(): void {
    this.employee=this.subjectService.getee();
    console.log(this.employee);
    
    this.departmentService.getAllDepartments().subscribe({
      next: data =>{
        this.departmentsList = data;
      },
      error: error =>{
        console.log(error);
      }
    });
  }
  updateEmployee(){
    if(this.employee.date>=this.employee.hiredate||this.employee.date>this.CurrentDate)
      this.birthDateStatus=true;
    else
      this.birthDateStatus=false;
    if(this.employee.gender==='0')
      this.genderStatus=true;
    else
      this.genderStatus=false;
    if(this.employee.hiredate<this.employee.date||this.employee.hiredate>this.CurrentDate)
      this.hireDateStatus=true;
    else
      this.hireDateStatus=false;
    if(this.employee.checkIn >= this.employee.checkOut)
      this.startTimeStatus=true;
    else
      this.startTimeStatus=false;
    if(this.employee.checkOut <= this.employee.checkIn)
      this.endTimeStatus=true;
    else
      this.endTimeStatus=false;
    if(!this.birthDateStatus&&!this.genderStatus&&!this.hireDateStatus&&!this.startTimeStatus&&!this.endTimeStatus)
    {
      console.log(this.employee.Department_Id);
      this.employeeService.update(this.employee).subscribe(
        {
          next: (data) => {
            this.router.navigate(['/employeeDetails',this.employee.id]);
          },
          error:(error:any) => {
            console.log(error);
            this.errorsList=error.error.errors;
            }}
      )
    }
  }
}
