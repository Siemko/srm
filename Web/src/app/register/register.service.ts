import { Injectable } from '@angular/core';
import { RegisterDTO } from '../../models/register.dto';
import { Observable } from 'rxjs/Observable';
import { HttpService } from '../_services/http.service';

@Injectable()
export class RegisterService {

  constructor(private http: HttpService) { }

  register(model: RegisterDTO): Observable<any> {
    return this.http.post("api/authentication/sign-up", model).map(res => res.json());
  }

}
