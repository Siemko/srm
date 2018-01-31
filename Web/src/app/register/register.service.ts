import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpService } from '../_services/http.service';
import { RegisterModel } from './models/register.model';

@Injectable()
export class RegisterService {

  constructor(private http: HttpService) { }

  register(model: RegisterModel): Observable<any> {
    return this.http.post("api/authentication/sign-up", model).map(res => res.json());
  }

}
