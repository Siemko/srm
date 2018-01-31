import { ChatsService } from './../chats.service';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { StudentsListService } from '../../students-list/students-list.service';

@Component({
  selector: 'app-add-chat',
  templateUrl: './add-chat.component.html',
  styleUrls: ['./add-chat.component.scss']
})
export class AddChatComponent implements OnInit {
  addChatForm: FormGroup;
  students: any[];
  constructor(private chatsService: ChatsService, private dialogRef: MatDialogRef<AddChatComponent>,
  private studentsService: StudentsListService) { }

  ngOnInit() {
    this.getStudents();
    this.initForm();
  }

  initForm() {
    this.addChatForm = new FormGroup({
      name: new FormControl('', Validators.required),
      studentIds: new FormControl([], [Validators.required, Validators.minLength(1)])
    });
  }

  addChat() {
    if (this.addChatForm.valid) {
      this.chatsService.addChat({ name: this.addChatForm.value.name, usersIds: this.addChatForm.value.studentIds}).subscribe(result => {
        if (result) {
          this.dialogRef.close(result);
        }
      });
    }
  }

  getStudents() {
    this.studentsService.getStudentsList().subscribe((result: any[]) => {
      this.students = result;
    });
  }

  cancel() {
    this.dialogRef.close(null);
  }

}
