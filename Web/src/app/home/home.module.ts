import { EventDetailsComponent } from './events/event-details/event-details.component';
import { ChatsService } from './chats/chats.service';
import { StudentsListService } from './students-list/students-list.service';
import { HomeRoutingModule } from './home-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { NavigationComponent } from './navigation/navigation.component';
import { RouterModule } from '@angular/router';
import { StudentsListComponent } from './students-list/students-list.component';
import { EventsComponent } from './events/events.component';
import { ChatsComponent } from './chats/chats.component';
import { MatListModule, MatIconModule, MatButtonModule, MatDialogModule,
   MatFormFieldModule, MatInputModule, MatTableModule, MatSelectModule, MatMenuModule, MatToolbarModule, MatChipsModule } from '@angular/material';
import { EventsService } from './events/events.service';
import { AddEventComponent } from './events/add-event/add-event.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AddChatComponent } from './chats/add-chat/add-chat.component';
import { SingleChatComponent } from './chats/single-chat/single-chat.component';
import {MatSidenavModule} from '@angular/material/sidenav';
import { ProfileComponent } from './profile/profile.component';
import { ProfileService } from './profile/profile.service';
import { EventsEntriesComponent } from './events-entries/events-entries.component';
import { RoleGuard } from '../_guards/role.guard';

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
    MatInputModule,
    MatSidenavModule,
    MatTableModule,
    MatSelectModule,
    MatMenuModule,
    MatToolbarModule,
    MatChipsModule
  ],
  declarations: [HomeComponent, NavigationComponent, StudentsListComponent, EventsComponent,
     ChatsComponent, AddEventComponent, AddChatComponent, SingleChatComponent, ProfileComponent, EventDetailsComponent, EventsEntriesComponent],
  providers: [StudentsListService, EventsService, ChatsService, ProfileService, RoleGuard],
  entryComponents: [AddEventComponent, AddChatComponent, SingleChatComponent, EventDetailsComponent]
})
export class HomeModule { }
