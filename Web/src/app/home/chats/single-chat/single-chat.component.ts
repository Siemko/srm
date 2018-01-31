import { ChatsService } from './../chats.service';
import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-single-chat',
  templateUrl: './single-chat.component.html',
  styleUrls: ['./single-chat.component.scss']
})
export class SingleChatComponent implements OnInit {
  message = 'chuj';
  chat: any;

  constructor(@Inject(MAT_DIALOG_DATA) data: any, private chatsService: ChatsService) {
    if(data) {
      this.chat = data;
    }
  }

  ngOnInit() {
  }

  addMessage() {
    if(this.message) {
      this.chatsService.addMessage(this.chat, this.message).subscribe(result => {
        this.message = '';
        if(result) {
          this.chat = result;
        }
      });
    }
  }
}
