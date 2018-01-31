import { ChatsService } from './../chats.service';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-add-chat',
  templateUrl: './add-chat.component.html',
  styleUrls: ['./add-chat.component.scss']
})
export class AddChatComponent implements OnInit {
  addChatForm: FormGroup;

  constructor(private chatsService: ChatsService, private dialogRef: MatDialogRef<AddChatComponent>) { }

  ngOnInit() {
    this.initForm();
  }

  initForm() {
    this.addChatForm = new FormGroup({
      name: new FormControl('', Validators.required)
    });
  }

  addChat() {
    if(this.addChatForm.valid) {
      this.chatsService.addChat({ name: this.addChatForm.value.name, usersIds: []}).subscribe(result => {
        if(result) {
          this.dialogRef.close(result);
        }
      });
    }
  }

  close() {
    this.dialogRef.close(null);
  }

}
