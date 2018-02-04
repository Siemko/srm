import { LocalStorageConst } from './../../_consts/local-storage.const';
import { Component, OnInit } from '@angular/core';
import { EventsService } from '../events/events.service';

@Component({
  selector: 'app-events-entries',
  templateUrl: './events-entries.component.html',
  styleUrls: ['./events-entries.component.scss']
})
export class EventsEntriesComponent implements OnInit {
  events: any[] = [];
  constructor(private eventsService: EventsService) {
    this.getEvents();
  }

  ngOnInit() {
    const userId = parseInt(
      localStorage.getItem(LocalStorageConst.USER_ID),
      10
    );
  }

  getEvents() {
    const userId = parseInt(
      localStorage.getItem(LocalStorageConst.USER_ID),
      10
    );
    this.eventsService.getActiveEvents().subscribe((result: any[]) => {
      result.forEach(e => {
        this.eventsService.getEventDetails(e.id).subscribe(res => {
          Object.assign(e, res);
        });
        this.isUserIn(e.id, userId);
      });
      console.log(result);
      this.events = result;
    });
  }

  join(eventId: number) {
    const userId = parseInt(
      localStorage.getItem(LocalStorageConst.USER_ID),
      10
    );
    if (userId) {
      this.eventsService.joinEvent(eventId, userId).subscribe(res => {
        if (res) {
          this.getEvents();
        }
      });
    }
  }

  resign(eventId: number) {
    const userId = parseInt(
      localStorage.getItem(LocalStorageConst.USER_ID),
      10
    );
    if (userId) {
      this.eventsService.removeUser(eventId, userId).subscribe(res => {
        if (res) {
          this.getEvents();
        }
      });
    }
  }

  isUserIn(eventId, userId) {
    this.eventsService.isUserJoined(eventId, userId).then(res => {
      this.events.map(event => {
        return event.id === eventId ? Object.assign(event, {isIn: res}) : event;
      });
    });
  }
}
