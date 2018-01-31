import { EventsComponent } from './events/events.component';
import { ChatsComponent } from './chats/chats.component';
import { StudentsListComponent } from './students-list/students-list.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'studentslist', component: StudentsListComponent, outlet: 'home' },
  { path: 'chats', component: ChatsComponent, outlet: 'home'},
  { path: 'events', component: EventsComponent}
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class HomeRoutingModule {}
