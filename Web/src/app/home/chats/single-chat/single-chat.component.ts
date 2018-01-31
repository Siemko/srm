import { ChatsService } from './../chats.service';
import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-single-chat',
  templateUrl: './single-chat.component.html',
  styleUrls: ['./single-chat.component.scss']
})
export class SingleChatComponent implements OnInit {
  message = '';
  chat: any;

  constructor(@Inject(MAT_DIALOG_DATA) data: any, private chatsService: ChatsService) {
    if(data) {
      this.chat = data;
    }
  }

  ngOnInit() {
    this.chatsService.getMessages(this.chat.id).subscribe(r => {
      this.chat.messages = r.messages
      console.log(this.chat)
    })
  }

  addMessage() {
    if(this.message) {
      this.chatsService.addMessage(this.chat.id, {content: this.message }).subscribe(result => {
        this.message = '';
        if(result) {
          this.chat = result;
        }
      });
    }
  }
}
