import { Injectable } from '@angular/core';
import { RegisterDTO } from '../../models/register.dto';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class RegisterService {

  constructor() { }

  register(registerDTO: RegisterDTO) {
    // STRZELAJ DO API
    return new Observable(observer => {
      observer.next(true);
    }); // było ok, można się zalogować
  }

}
