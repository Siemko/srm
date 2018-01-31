import { MatDialogRef } from '@angular/material';
import { FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { EventsService } from '../events.service';

@Component({
  selector: 'app-add-event',
  templateUrl: './add-event.component.html',
  styleUrls: ['./add-event.component.scss']
})
export class AddEventComponent implements OnInit {
  addEventForm: FormGroup;
  eventsCategories: any[] = [];

  constructor(private dialogRef: MatDialogRef<AddEventComponent>, private eventsService: EventsService) { }

  ngOnInit() {
    this.getEventsCategories();
    this.initForm();
  }

  initForm() {
    this.addEventForm = new FormGroup({
      name: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
      category: new FormControl('', Validators.required),
      maxNumberOfPerson: new FormControl(0, Validators.required)
    });
  }

  addEvent() {
    if (this.addEventForm.valid) {
      this.eventsService.addEvent(this.addEventForm.value.name, this.addEventForm.value.description,
         this.addEventForm.value.category, this.addEventForm.value.maxNumberOfPerson).subscribe(result => {
        if(result) {
          this.dialogRef.close(result);
        }
      });
    }
  }


  getEventsCategories() {
    this.eventsService.getEventsCategories().subscribe((result: any[]) => {
      this.eventsCategories = result;
    });
  }

  cancel() {
    this.dialogRef.close(null);
  }

}
