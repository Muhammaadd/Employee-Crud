import { EditEmployeeComponent } from './Components/edit-employee/edit-employee.component';
import { EmployeeDetailsComponent } from './Components/employee-details/employee-details.component';
import { EmployeeComponent } from './Components/employee/employee.component';
import { AddEmployeeComponent } from './Components/add-employee/add-employee.component';
import { CheckLoginGuard } from './Guards/check-login.guard';
import { HeaderComponent } from './Components/header/header.component';
import { AsideComponent } from './Components/aside/aside.component';
import { PageNotFoundComponent } from './Components/page-not-found/page-not-found.component';
import { HomeComponent } from './Components/home/home.component';
import { RegisterComponent } from './Components/register/register.component';
import { LoginComponent } from './Components/login/login.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticationGuard } from './Guards/authentication.guard';

const routes: Routes = [
  {path:'home',component:HomeComponent,canActivate:[AuthenticationGuard]},
  {path:'login',component:LoginComponent,canActivate:[CheckLoginGuard]},
  {path:'register',component:RegisterComponent},
  {path:'aside',component:AsideComponent},
  {path:'header',component:HeaderComponent},
  {path:'addEmployee',component:AddEmployeeComponent,canActivate:[AuthenticationGuard]},
  {path:'editEmployee/:id',component:EditEmployeeComponent},
  {path:'employee',component:EmployeeComponent},
  {path:'employeeDetails/:id',component:EmployeeDetailsComponent},
  {path:'',component:HomeComponent,canActivate:[AuthenticationGuard]},
  {path:'**',component:PageNotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
