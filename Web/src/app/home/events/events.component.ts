import { Component, OnInit } from '@angular/core';
import { EventsService } from './events.service';
import { MatDialog, MatTableDataSource } from '@angular/material';
import { AddEventComponent } from './add-event/add-event.component';
import { EventDetailsComponent } from './event-details/event-details.component';
import { LocalStorageConst } from '../../_consts/local-storage.const';
import { Router } from '@angular/router';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss']
})
export class EventsComponent implements OnInit {
  events: any[] = [];
  joined = false;
  eventsCategories: any[] = [];

  constructor(private eventsService: EventsService,private router: Router, private dialog: MatDialog) {
  }

  ngOnInit() {
    this.getEvents();
    const role = localStorage.getItem(LocalStorageConst.ROLE_NAME).toLocaleLowerCase();
    if (role !== 'starosta') {
      this.router.navigate(['home/profile']);
    }
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
    this.eventsService.activate(event.id).subscribe(result => {
      event.activated = true;
    });
  }

  deactivate(event) {
    this.eventsService.deactivate(event.id).subscribe(result => {
      event.activated = false;
    });
  }

  openDetails(event) {
    const singleChatDialog = this.dialog.open(EventDetailsComponent, {
      data: { eventId: event.id }
    });
  }
}
