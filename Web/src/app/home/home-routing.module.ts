import { EventsComponent } from './events/events.component';
import { ChatsComponent } from './chats/chats.component';
import { StudentsListComponent } from './students-list/students-list.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RoleGuard } from '../_guards/role.guard';

const routes: Routes = [
  { 
    path: 'studentslist', 
    component: StudentsListComponent,
    canActivate: [RoleGuard],
    data: {
        pageTitle: 'Warehouse',
        roles: ['starosta']
    },
    outlet: 'home'
  },
  { 
    path: 'chats', 
    component: ChatsComponent,
    canActivate: [RoleGuard],
    data: {
        pageTitle: 'Warehouse',
        roles: ['starosta', 'student']
    },
    outlet: 'home'
  },
  { path: 'events', component: EventsComponent}
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class HomeRoutingModule {}
