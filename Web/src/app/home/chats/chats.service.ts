import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ChatsService {
  id = 0;
  constructor() { }

  getChats() {
    return new Observable(observer => {
      observer.next([
        {name: 'general', users: [], messages: ['Elo', 'Co tam', 'Cho na piwo'], id: this.id++}
      ]);
    });
  }

  addChat(name: string) {
    return new Observable(observer => {
      observer.next({name, users: [], messages: [], id: this.id++});
    });
  }

  addMessage(chat: any, message: string) {
    return new Observable(observer => {
      chat.messages.push(message);
      observer.next(chat);
    });
  }
}
