import { Component, OnInit } from '@angular/core';
import { EventsService } from '../events/events.service';

@Component({
  selector: 'app-events-entries',
  templateUrl: './events-entries.component.html',
  styleUrls: ['./events-entries.component.scss']
})
export class EventsEntriesComponent implements OnInit {

  events: any[];
  constructor(private eventsService: EventsService) { }

  ngOnInit() {
    this.getEvents();
  }

  getEvents() {
    this.eventsService.getActiveEvents().subscribe((result: any[]) => {
      this.events = result;
    });
  }

}
