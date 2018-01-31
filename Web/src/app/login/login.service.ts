import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { User } from '../../models/user';
import { Router } from '@angular/router';
import { HttpService } from '../_services/http.service';
import { LoginModel } from './models/login.model';

@Injectable()
export class LoginService {

  constructor(private http: HttpService, private router: Router) { }

  login(model: LoginModel): Observable<any> {
    return this.http.post("api/authentication/sign-in", model).map(res => res.json());
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

   saveToken(token: string) {
    localStorage.setItem('token', token);
  }

  public signOut() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }


}
