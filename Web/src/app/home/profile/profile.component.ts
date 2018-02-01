import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { ProfileService } from './profile.service';
import { LocalStorageConst } from '../../_consts/local-storage.const';
import { StudentsListService } from '../students-list/students-list.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  profileForm: FormGroup;
  user: any;
  studentsGroups: any[];

  constructor(private profileService: ProfileService, private studentListService: StudentsListService) {
  }

  ngOnInit() {
    this.getUserProfile();
    this.getStudentsGroups();
    this.initFormGroup();
  }

  getUserProfile() {
    const userId = parseInt(localStorage.getItem(LocalStorageConst.USER_ID), 10);
    console.log(userId);
    if (userId) {
      this.profileService.getProfile(userId).subscribe((result: any) => {
        console.log(result);
        this.user = result;
        this.profileForm.setValue({
          name: result.name,
          surname: result.surname,
          description: result.description,
          studentNumber: result.studentNumber,
          studentGroupId: result.studentGroupId,
          email: result.email
        });
      });
    }
  }

  getStudentsGroups() {
    this.studentListService.getStudentsGroupsList().subscribe((result: any[]) => {
      this.studentsGroups = result;
    });
  }

  initFormGroup() {
    this.profileForm = new FormGroup({
      name: new FormControl('', Validators.required),
      surname: new FormControl('', Validators.required),
      email: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
      studentNumber: new FormControl('', Validators.required),
      studentGroupId: new FormControl('', Validators.required),
    });
  }

  editStudent() {
    if (this.profileForm.valid) {
      this.profileService.editProfile(this.profileForm.value).subscribe(result => {
        if (result) {
          this.getUserProfile();
        }
      });
    }
  }
}
