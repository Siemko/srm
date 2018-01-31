import { Component, OnInit } from '@angular/core';
import { EventsService } from './events.service';
import { MatDialog } from '@angular/material';
import { AddEventComponent } from './add-event/add-event.component';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss']
})
export class EventsComponent implements OnInit {
  events: any[] = [];
  joined = false;
  eventsCategories: any[] = [];
  constructor(private eventsService: EventsService, private dialog: MatDialog) {
  }

  ngOnInit() {
    this.getEvents();
  }

  getEvents() {
    this.eventsService.getEvents().subscribe((result: any[]) => {
      this.events = result;
    });
  }

  addEvent() {
    const addEventDialog = this.dialog.open(AddEventComponent, {});

    addEventDialog.afterClosed().subscribe(result => {
      if (result) {
        this.getEvents();
      }
    });
  }

  activate(event) {
    this.eventsService.activate(event).subscribe(result => {
      event = result;
    });
  }

  deactivate(event) {
    this.eventsService.deactivate(event).subscribe(result => {
      event = result;
    });
  }
}
