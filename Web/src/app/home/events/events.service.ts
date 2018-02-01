import { AddEventDTO } from './../../login/models/addEvent.dto';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { HttpService } from '../../_services/http.service';

@Injectable()
export class EventsService {

  constructor(private http: HttpService) { }

  getEvents() {
    return this.http.get(`api/event`).map(res => res.json());
  }

  getEventsCategories() {
    return this.http.get(`api/event/categories`).map(res => res.json());
  }

  addEvent(name: string, description: string, category: number, max: number) {
    const model: AddEventDTO = {
      name: name,
      description: description,
      categoryId: category,
      maxNumberOfPerson: max
    };
    return this.http.post(`api/event`, model).map(res => res.json());
  }

  getEventDetails(eventId) {
    return this.http.get(`api/event/${eventId}`).map(res => res.json());
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

  joinEvent(eventId: number, userId: number) {
    return this.http.put(`api/event/${eventId}/assign-user/${userId}`, {}).map(res => res.json());
  }

  getActiveEvents() {
    return this.http.get(`api/event/activated`).map(res => res.json());
  }
}
