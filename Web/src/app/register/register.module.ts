import { AppRoutingModule } from './../app-routing.module';
import { RegisterService } from "./register.service";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RegisterComponent } from "./register.component";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import {
  MatInputModule,
  MatButtonModule,
  MatCardModule
} from "@angular/material";
import { RouterModule } from "@angular/router";
import { ServiceModule } from '../_services/service.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    RouterModule,
    AppRoutingModule,
    ServiceModule
  ],
  providers: [RegisterService],
  declarations: [RegisterComponent]
})
export class RegisterModule {}
