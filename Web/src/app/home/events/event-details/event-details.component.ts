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
  details: any;

  constructor(@Inject(MAT_DIALOG_DATA) data: any, private eventsService: EventsService, private studentsService: StudentsListService) {
    if (data) {
      this.event = data;
    }
  }

  ngOnInit() {
    this.getDetails(this.event.id);
    this.getActiveStudents();
  }

  getActiveStudents() {
    this.studentsService.getStudentsList().subscribe((result: any[]) => {
      this.activeStudents = result;
    });
  }

  getDetails(eventID: number) {
    this.eventsService.getEventDetails(eventID).subscribe((result: any) => {
      this.details = result;
      this.students = result.users;
    });
  }

  addStudent(student: any) {
    this.eventsService.joinEvent(this.event.id, student.id).subscribe((result: any) => {
      if (result) {
        console.log(result);
        this.getDetails(this.event.id);
      }
    });
  }
}
