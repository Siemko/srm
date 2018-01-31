import { ProfileDTO } from './../../../models/profile.dto';
import { Injectable } from '@angular/core';
import { HttpService } from '../../_services/http.service';

@Injectable()
export class ProfileService {

  constructor(private http: HttpService) { }

  getProfile(studentId: number) {
    this.http.get(`/api/user/${studentId}`).map(res => res.json());
  }

  editProfile(model: ProfileDTO) {
    this.http.put(`/api/user/${model.id}`, model).map(res => res.json());
  }

}
