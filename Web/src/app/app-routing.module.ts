import { StudentsListComponent } from './home/students-list/students-list.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './login/login.component';
import { EventsComponent } from './home/events/events.component';
import { ChatsComponent } from './home/chats/chats.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'home', canActivate: [AuthGuard],  component: HomeComponent, children: [
      { path: 'studentslist', component: StudentsListComponent},
      { path: 'events', component: EventsComponent},
      { path: 'chats', component: ChatsComponent}
    ] 
  }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
