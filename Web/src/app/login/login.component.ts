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
      login: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
    });
  }

  handleLogin() {
    if(this.loginForm.valid) {
      this.loginService.login(this.loginForm.value.login, this.loginForm.value.password).subscribe(result => {
        if(result) {
          this.router.navigate(['home']);
        }
      });
    }
    // todo: service with login
  }

  handlePasswordRemind() {
    this.dialog.open(ConfirmationComponent, {});
  }

}
