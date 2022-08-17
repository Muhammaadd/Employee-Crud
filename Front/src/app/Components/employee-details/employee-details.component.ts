import { SubjectsService } from './../../Services/subjects.service';
import { EmployeeService } from 'src/app/Services/employee.service';
import { IEmployeeDetails } from './../../ViewModels/iemployee-details';
import { Component, OnInit, AfterViewInit, ViewChild, ElementRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.css']
})
export class EmployeeDetailsComponent implements OnInit {
employeeId!:number;
employee!:IEmployeeDetails;
  constructor(private subjectService:SubjectsService,private employeeService:EmployeeService,private activateRoute:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.employee={
      date:new Date(),
      checkIn:"",
      checkOut:"",
      hiredate:new Date(),
    }
    this.activateRoute.params.subscribe(x=>
      {
        this.employeeId=x['id'];
        this.employeeService.getById(this.employeeId).subscribe({
          next:data=>{
            this.employee = data;
            this.employee.id =this.employeeId;
            console.log("gg",this.employee);
          },
          error:error=>{
            this.router.navigate(['/employee'])
          }
        })
      });
  }
  deleteEmployee(){
    var status = confirm("Are you sure ?");
    if(status)
      this.employeeService.deleteById(this.employeeId);
  }
  setSubject(){
    console.log(this.employee);
    // this.subjectService.setEmployeeToEditForm(this.employee);
    this.subjectService.setee(this.employee);
  }
}
