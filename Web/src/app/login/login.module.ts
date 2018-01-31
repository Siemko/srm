import { AppRoutingModule } from './../app-routing.module';
import { LoginService } from './login.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login.component';
import {  MatInputModule, MatButtonModule, MatDialogModule, MatCardModule } from '@angular/material';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ConfirmationComponent } from './confirmation/confirmation.component';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    AppRoutingModule
  ],
  declarations: [LoginComponent, ConfirmationComponent],
  providers: [
    LoginService,
  ],
  entryComponents: [
    ConfirmationComponent,
  ]
})
export class LoginModule { }
