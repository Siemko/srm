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
    if (data) {
      this.event = data;
    }
  }

  ngOnInit() {
    this.getStudents();
    this.getActiveStudents();
  }

  getActiveStudents() {
    this.studentsService.getStudentsList().subscribe((result: any[]) => {
      this.activeStudents = result;
    });
  }

  getStudents() {
    this.eventsService.getEventStudents().subscribe((result: any[]) => {
      this.students = result;
    });
  }

  addStudent(student: any) {
    this.eventsService.joinEvent(this.event.id, student.id).subscribe((result: any) => {
      if (result) {
        console.log(result);
        this.getStudents();
      }
    });
  }
}
