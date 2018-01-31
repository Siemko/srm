import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';

@Injectable()
export class EventsService {

  constructor() { }

  getEvents() {
    return new Observable(observer => {
      observer.next([
        { name: 'Zapisy', description: 'na piwo', activated: true },
        { name: 'Podpisy', description: 'oceny', activated: false}
      ]);
    });
  }

  addEvent(name: string, description: string) {
    return new Observable(observer => {
      observer.next({
        name,
        description,
        activated: false,
        users: []
      });
    });
  }

  activate(event: any) {
    return new Observable(observer => {
      event.activated = true;
      observer.next(event);
    });
  }

  deactivate(event: any) {
    return new Observable(observer => {
      event.activated = false;
      observer.next(event);
    });
  }
}
