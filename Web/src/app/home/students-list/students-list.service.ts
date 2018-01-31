import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class StudentsListService {

  constructor() { }

  getStudentsList() {
    return new Observable(observer => {
      observer.next([
        {name: 'Dominik', surname: 'Guzy', albumNumber: 126039},
        {name: 'Dawid', surname: 'Świerczek', albumNumber: 231980}
      ]);
    });
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
