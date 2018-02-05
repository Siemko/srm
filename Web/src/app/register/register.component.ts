import { RegisterService } from './register.service';
import { FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { FormArray } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterModel } from './models/register.model';
import { PasswordValidation } from './register.match-password.validator';
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
      email: new FormControl('', [Validators.email, Validators.required]),
      confirmEmail: new FormControl('', [Validators.email, Validators.required]),
      password: new FormControl('', [Validators.required, Validators.minLength(8)]),
      confirmPassword: new FormControl('', [Validators.required, Validators.minLength(8)]),
      name: new FormControl('', Validators.required),
      surname: new FormControl('', Validators.required)
    }, {
      validators: PasswordValidation.MatchPassword
    });
  }

  getErrorMessage(field) {
    return field.hasError('required') ? 'Pole wymagane.' :
           field.hasError('email') ? 'Nieprawidłowy adres email.' :
           field.hasError('minlength') ? 'Minimalna długość 8 znaków.' :
            '';
  }

  handleRegister() {
    if (this.registerForm.valid) {
      const model = <RegisterModel>{
        email: this.registerForm.value.email,
        password: this.registerForm.value.password,
        name: this.registerForm.value.name,
        surname: this.registerForm.value.surname
      };

      this.registerService.register(model)
                  .subscribe(() => this.router.navigate(['login']));

    }
  }
}