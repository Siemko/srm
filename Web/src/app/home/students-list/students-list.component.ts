import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { StudentsListService } from './students-list.service';
import { MatTableDataSource } from '@angular/material';
import { LocalStorageConst } from '../../_consts/local-storage.const';
import { Router } from '@angular/router';

@Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
  styleUrls: ['./students-list.component.scss']
})
export class StudentsListComponent implements OnInit {
  studentsList: any[];
  displayedColumns = ['id', 'name', 'surname', 'studentNumber', 'action'];
  studentsGroupsList: any[];

  selectedActivated: boolean;
  selectedDectivated: boolean;
  selectedStudentGroup: boolean;
  selectedAll: boolean;

  dataSource = new MatTableDataSource<any>(this.studentsList);
  loading: boolean = true;

  constructor(private studentsListService: StudentsListService,
    private router: Router,
     private changeDetectorRefs: ChangeDetectorRef) {
   }


  ngOnInit() {
    this.getStudetnsGroupsList();
    this.showActivated();

    let role = localStorage.getItem(LocalStorageConst.ROLE_NAME).toLocaleLowerCase();
    if(role != 'starosta')
      this.router.navigate(['home/profile']);
  }

  refreshTable(users: any[]) {
    this.studentsList = users;
    this.dataSource = new MatTableDataSource<any>(this.studentsList);
    this.changeDetectorRefs.detectChanges();
  }

  getStudetnsGroupsList() {
    this.studentsListService.getStudentsGroupsList().subscribe((result: any[]) => {
      this.studentsGroupsList = result;
    });
  }

  banStudent(student) {
    this.studentsListService.banStudent(student.id).subscribe(result => {
      student.active = false;
    });
  }

  activateStudent(student) {
    this.studentsListService.activateStudent(student.id).subscribe(result => {
      student.active = true;
    });
  }

  showActivated() {
    this.selectedActivated = true;
    this.selectedDectivated = false;
    this.selectedStudentGroup = false;
    this.selectedAll = false;
    this.studentsListService.getActivatedStudents().subscribe((result: any[]) => {
      this.refreshTable(result);
    });
  }

  showDeactivated() {
    this.selectedDectivated = true;
    this.selectedActivated = false;
    this.selectedStudentGroup = false;
    this.selectedAll = false;
    this.studentsListService.getDeactivatedStudents().subscribe((result: any[]) => {
      this.refreshTable(result);
    });
  }

  showStudentGroup(studentGroupId:number) {
    this.selectedStudentGroup = true;
    this.selectedActivated = false;
    this.selectedActivated = false;
    this.selectedAll = false;
    this.studentsListService.getStudentsByStudentGroup(studentGroupId).subscribe((result: any[]) => {
      this.refreshTable(result);
    });
  }

  showAll() {
    this.selectedAll = true;
    this.selectedStudentGroup = false;
    this.selectedActivated = false;
    this.selectedActivated = false;
    this.studentsListService.getStudentsList().subscribe((result: any[]) => {
      this.refreshTable(result);
    });
  }
}
