import { LoginService } from './login.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Validators } from '@angular/forms';
import { MatDialog } from '@angular/material';
import { ConfirmationComponent } from './confirmation/confirmation.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;

  constructor(private router: Router, private loginService: LoginService, private dialog: MatDialog) {
    this.initializeForm();
  }

  ngOnInit() {
  }

  initializeForm() {
    this.loginForm = new FormGroup({
      email: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
    });
  }

  handleLogin() {
    if (this.loginForm.valid) {
      this.loginService.login({email: this.loginForm.value.email, password: this.loginForm.value.password}).subscribe(result => {
        console.log(result);
        if (result.token) {
          this.loginService.saveLoginModel(result);
          this.router.navigate(['/home']);
        }
      });
    }
  }

  handlePasswordRemind() {
    this.dialog.open(ConfirmationComponent, {});
  }

}
