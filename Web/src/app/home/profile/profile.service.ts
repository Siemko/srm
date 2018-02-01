import { ProfileDTO } from './../../../models/profile.dto';
import { Injectable } from '@angular/core';
import { HttpService } from '../../_services/http.service';
import { LocalStorageConst } from '../../_consts/local-storage.const';

@Injectable()
export class ProfileService {

  constructor(private http: HttpService) { }

  getProfile(studentId: number) {
    return this.http.get(`api/user/${studentId}`).map(res => res.json());
  }

  editProfile(student: any) {
    const userId = parseInt(localStorage.getItem(LocalStorageConst.USER_ID), 10);
    const model: ProfileDTO = {
      id: userId,
      name: student.name,
      surname: student.surname,
      description: student.description,
      email: student.email,
      studentGroupId: student.studentGroupId,
      studentNumber: student.studentNumber
    };
    return this.http.put(`api/user/`, model).map(res => res.json());
  }

}
