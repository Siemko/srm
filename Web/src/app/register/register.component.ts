import { RegisterDTO } from './../../models/register.dto';
import { RegisterService } from './register.service';
import { FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { FormArray } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;

  constructor(private registerService: RegisterService, private router: Router) { }

  ngOnInit() {
    this.initForm();
  }

  initForm() {
    this.registerForm = new FormGroup({
      email: new FormControl('', Validators.email),
      confirmEmail: new FormControl('', Validators.email),
      password: new FormControl('', Validators.required),
      name: new FormControl('', Validators.required),
      surname: new FormControl('', Validators.required)
    });
  }

  handleRegister() {
    if (this.registerForm.valid) {
      const registerDto = <RegisterDTO>{
        email: this.registerForm.value.email,
        confirmEmail: this.registerForm.value.confirmEmail,
        password: this.registerForm.value.password,
        name: this.registerForm.value.name,
        surname: this.registerForm.value.surname
      };

      this.registerService.register(registerDto).subscribe(result => {
        if(result) {
          this.router.navigate(['login']);
        }

      });

    }
  }
}