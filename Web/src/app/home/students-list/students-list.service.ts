import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpService } from '../../_services/http.service';

@Injectable()
export class StudentsListService {

  constructor(private http: HttpService) { }
  
  getStudentsList(): Observable<any> {
    return this.http.get("api/user").map(res => res.json());
  }

  activateStudent(student: any) {
    return new Observable(observer => {
      student.activated = true;
      observer.next(student);
    });
  }

  banStudent(student: any) {
    return new Observable(observer => {
      student.banned = true;
      observer.next(student);
    });
  }
}
