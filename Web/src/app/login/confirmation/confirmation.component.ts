import { FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { FormControl } from '@angular/forms';
import { LoginService } from '../login.service';

@Component({
  selector: 'app-confirmation',
  templateUrl: './confirmation.component.html',
  styleUrls: ['./confirmation.component.scss']
})
export class ConfirmationComponent implements OnInit {

  passwordRemindForm: FormGroup;
  constructor(private dialogRef: MatDialogRef<ConfirmationComponent>, 
    private loginService: LoginService) { }

  ngOnInit() {
    this.initForm();
  }

  initForm() {
    this.passwordRemindForm = new FormGroup({
      email: new FormControl('', [Validators.email, Validators.required])
    });
  }

  handlePasswordRemind() {
    console.log(this.passwordRemindForm);
    this.loginService.remindPassword('')
                      .subscribe(r => { this.dialogRef.close(); })
  }

}
