import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { User } from '../../models/user';
import { Router } from '@angular/router';
import { HttpService } from '../_services/http.service';
import { LoginModel } from './models/login.model';
import { LoginResponseModel } from './models/login-response.model';
import { LocalStorageConst } from '../_consts/local-storage.const';

@Injectable()
export class LoginService {

  constructor(private http: HttpService, private router: Router) { }

  login(model: LoginModel): Observable<LoginResponseModel> {
    return this.http.post("api/authentication/sign-in", model).map(res => res.json());
  }

  remindPassword(model: any): Observable<LoginResponseModel> {
    return this.http.post("api/authentication/remind-password", model).map(res => res.json());
  }

  isLoggedIn() {
    const token = localStorage.getItem('token');
    return !(!token);
  }

  isLoggedOut() {
    return !this.isLoggedIn();
  }

  signOut() {
    this.clearLoginModel();
    this.router.navigate(['/login']);
  }

  saveLoginModel(model: LoginResponseModel) {
    localStorage.setItem(LocalStorageConst.TOKEN, model.token);
    localStorage.setItem(LocalStorageConst.USER_ID, model.id.toString());
    localStorage.setItem(LocalStorageConst.USER_EMAIL, model.userName);
    localStorage.setItem(LocalStorageConst.ROLE_NAME, model.roleName);
  }

  private clearLoginModel() {
    localStorage.removeItem(LocalStorageConst.TOKEN);
    localStorage.removeItem(LocalStorageConst.USER_ID);
    localStorage.removeItem(LocalStorageConst.USER_EMAIL);
    localStorage.removeItem(LocalStorageConst.ROLE_NAME);
  }


}
