import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { User } from '../../models/user';

@Injectable()
export class LoginService {

  constructor() { }

  login(login: string, password: string) {
    return new Observable(observer => {
      observer.next('xxxx');
    });
  }

  isLoggedIn() {
    const token = localStorage.getItem('token');
    return !(!token);
  }

  isLoggedOut() {
    return !this.isLoggedIn();
  }

  getUser() {
    if (this.isLoggedIn()) {
      const user = new User();
      user.login = 'starosta';
      user.name = 'Dawid';
      user.surname = 'Świerczek';
      user.role = 'Admin';

      return user;
    }
    return null;
  }

  private saveToken(token: string) {
    localStorage.setItem('token', token);
  }
}
