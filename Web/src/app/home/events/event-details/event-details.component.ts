import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Component, OnInit, Inject } from '@angular/core';
import { EventsService } from '../events.service';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.scss']
})
export class EventDetailsComponent implements OnInit {
  event: any;

  constructor(@Inject(MAT_DIALOG_DATA) data: any, private eventsService: EventsService) {
    if (data) {
      this.event = data;
    }
  }

  ngOnInit() {
  }

}
