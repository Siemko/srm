import { Component, OnInit } from '@angular/core';
import { StudentsListService } from './students-list.service';

@Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
  styleUrls: ['./students-list.component.scss']
})
export class StudentsListComponent implements OnInit {
  studentsList: any[];

  constructor(private studentsListService: StudentsListService) { }

  ngOnInit() {
    this.getStudentsList();
  }

  getStudentsList() {
    this.studentsListService.getStudentsList().subscribe((result: any[]) => {
      this.studentsList = result;
    });
  }

  banStudent(student) {
    this.studentsListService.banStudent(student).subscribe(result => {

    });
  }

  activateStudent(student) {
    this.studentsListService.activateStudent(student).subscribe(result => {
      
    });
  }

}
