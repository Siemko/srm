import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { StudentsListService } from './students-list.service';
import { MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
  styleUrls: ['./students-list.component.scss']
})
export class StudentsListComponent implements OnInit {
  studentsList: any[];
  displayedColumns = ['id', 'name', 'surname', 'studentNumber', 'action'];
  studentsGroupsList: any[];

  dataSource = new MatTableDataSource<any>(this.studentsList);
  loading: boolean = true;

  constructor(private studentsListService: StudentsListService, private changeDetectorRefs: ChangeDetectorRef) {
   }


  ngOnInit() {
    this.getStudetnsGroupsList();
    this.getStudentsList();
  }

  getStudentsList() {
    this.studentsListService.getStudentsList().subscribe((result: any[]) => {
      console.log(result)
      this.studentsList = result;
      this.dataSource = new MatTableDataSource<any>(this.studentsList);
      this.changeDetectorRefs.detectChanges();
    });
  }

  getStudetnsGroupsList() {
    this.studentsListService.getStudentsGroupsList().subscribe((result: any[]) => {
      this.studentsGroupsList = result;
    });
  }

  banStudent(student) {
    this.studentsListService.banStudent(student.id).subscribe(result => {

    });
  }

  activateStudent(student) {
    this.studentsListService.activateStudent(student.id).subscribe(result => {
      
    });
  }

}
