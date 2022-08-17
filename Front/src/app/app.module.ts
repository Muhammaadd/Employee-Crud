import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Components/login/login.component';
import { RegisterComponent } from './Components/register/register.component';
import { HomeComponent } from './Components/home/home.component';
import { PageNotFoundComponent } from './Components/page-not-found/page-not-found.component';
import { AsideComponent } from './Components/aside/aside.component';
import { HeaderComponent } from './Components/header/header.component';
import { AddEmployeeComponent } from './Components/add-employee/add-employee.component';
import { EmployeeComponent } from './Components/employee/employee.component';
import { EmployeeDetailsComponent } from './Components/employee-details/employee-details.component';
import { EditEmployeeComponent } from './Components/edit-employee/edit-employee.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    PageNotFoundComponent,
    AsideComponent,
    HeaderComponent,
    AddEmployeeComponent,
    EmployeeComponent,
    EmployeeDetailsComponent,
    EditEmployeeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
