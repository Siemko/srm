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

  
  dataSource = new MatTableDataSource<any>(this.studentsList);
  loading: boolean = true;

  constructor(private studentsListService: StudentsListService, private changeDetectorRefs: ChangeDetectorRef) {
   }


  ngOnInit() {
    this.getStudentsList();
  }

  getStudentsList() {
    this.studentsListService.getStudentsList().subscribe((result: any[]) => {
      this.studentsList = result;
      this.dataSource = new MatTableDataSource<any>(this.studentsList);
      this.changeDetectorRefs.detectChanges();
      console.log(result);
      
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
