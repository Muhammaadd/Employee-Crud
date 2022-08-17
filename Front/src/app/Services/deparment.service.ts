import { IDepartment } from './../ViewModels/idepartment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class DeparmentService {
  constructor(private httpClient:HttpClient,private router:Router) { }
  getAllDepartments(){
    return this.httpClient.get<IDepartment[]>('http://localhost:5203/api/Department');
  }
}
