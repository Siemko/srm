import { ChatsService } from './chats/chats.service';
import { StudentsListService } from './students-list/students-list.service';
import { HomeRoutingModule } from './home-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { HeaderComponent } from './header/header.component';
import { RouterModule } from '@angular/router';
import { StudentsListComponent } from './students-list/students-list.component';
import { EventsComponent } from './events/events.component';
import { ChatsComponent } from './chats/chats.component';
import { MatListModule, MatIconModule, MatButtonModule, MatDialogModule, MatFormFieldModule, MatInputModule } from '@angular/material';
import { EventsService } from './events/events.service';
import { AddEventComponent } from './events/add-event/add-event.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AddChatComponent } from './chats/add-chat/add-chat.component';
import { SingleChatComponent } from './chats/single-chat/single-chat.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatListModule,
    MatIconModule,
    MatButtonModule,
    MatDialogModule,
    MatInputModule
  ],
  declarations: [HomeComponent, HeaderComponent, StudentsListComponent, EventsComponent, ChatsComponent, AddEventComponent, AddChatComponent, SingleChatComponent],
  providers: [StudentsListService, EventsService, ChatsService],
  entryComponents: [AddEventComponent, AddChatComponent, SingleChatComponent]
})
export class HomeModule { }
