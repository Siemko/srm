import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Component, OnInit, Inject } from '@angular/core';
import { EventsService } from '../events.service';
import { StudentsListService } from '../../students-list/students-list.service';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.scss']
})
export class EventDetailsComponent implements OnInit {
  event: any;
  students: any[] = [];
  activeStudents: any[] = [];

  constructor(@Inject(MAT_DIALOG_DATA) data: any, private eventsService: EventsService, private studentsService: StudentsListService) {
    if(data) {
      this.eventsService.getEvent(data.eventId).subscribe(e => this.event = e);
    }
  }

  ngOnInit() {
    this.getActiveStudents();
  }

  getActiveStudents() {
    this.studentsService.getStudentsList().subscribe((result: any[]) => {
      this.activeStudents = result;
    });
  }

  addStudent(student: any) {
    this.eventsService.joinEvent(this.event.id, student.id).subscribe((result: any) => {
      this.event.users.push(student);
    });
  }

  deleteStudent(student: any) {
    this.eventsService.removeUser(this.event.id, student.id).subscribe((result: any) => {
      var index = this.event.users.indexOf(u => u.id == student.id);
      this.event.users.splice(index, 1);
    });
  }
}
