import { IEmployeeView } from './../../ViewModels/iemployee-view';
import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/Services/employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
employeesList!:IEmployeeView[];
  constructor(private employeeService:EmployeeService) { }

  ngOnInit(): void {
    this.employeeService.getAllEmployees().subscribe({
      next : data => {
        this.employeesList = data
      },
      error : error => {
        this.employeesList=[]
      }
    });
  }

}
