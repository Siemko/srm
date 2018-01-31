import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpService } from '../../_services/http.service';

@Injectable()
export class StudentsListService {

  constructor(private http: HttpService) { }
  
  getStudentsList(): Observable<any> {
    return this.http.get("api/user").map(res => res.json());
  }

  activateStudent(studentId: number) {
    return this.http.put(`api/user/${studentId}/activate`, {}).map(res => res.json());
  }

  banStudent(studentId: number) {
    return this.http.put(`api/user/${studentId}/disable`, {}).map(res => res.json());
  }
}
