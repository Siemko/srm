import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpService } from '../../_services/http.service';

@Injectable()
export class ChatsService {
  constructor(private http: HttpService) { }

  getChats() {
    return this.http.get(`api/chat/`).map(res => res.json());
  }

  getMessages(chatId: number) {
    return this.http.get(`api/chat/${chatId}`).map(res => res.json());
  }

  addChat(chat: any) {
    return this.http.post(`api/chat/`, chat).map(res => res.json());
  }

  assignToChat(chatId: any) {
    return this.http.put(`api/chat/${chatId}/assign`, {}).map(res => res.json());
  }

  leftChat(chatId: any) {
    return this.http.put(`api/chat/${chatId}/left`, {}).map(res => res.json());
  }

  addMessage(chatId: number, message: any) {
    return this.http.post(`api/chat/${chatId}/message`, message).map(res => res.json());
  }

  deleteMessage(chatId: number, messageId: number) {
    return this.http.delete(`api/chat/${chatId}/message/${messageId}`).map(res => res.json());
  }
}
