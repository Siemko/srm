import { SingleChatComponent } from './single-chat/single-chat.component';
import { ChatsService } from './chats.service';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { AddChatComponent } from './add-chat/add-chat.component';

@Component({
  selector: 'app-chats',
  templateUrl: './chats.component.html',
  styleUrls: ['./chats.component.scss']
})
export class ChatsComponent implements OnInit {
  chats: any[];
  messages: any[];

  constructor(private chatsService: ChatsService, private dialog: MatDialog) { }

  ngOnInit() {
    this.getChats();
  }

  getChats() {
    this.chatsService.getChats().subscribe((result: any[]) => {
      this.chats = result;
    });
  }

  addChat() {
    const addchatDialog = this.dialog.open(AddChatComponent, {});

    addchatDialog.afterClosed().subscribe(result => {
      if(result) {
        this.getChats();
      }
    });
  }

  openDetails(chat) {
    const singleChatDialog = this.dialog.open(SingleChatComponent, {
      data: chat
    });

    singleChatDialog.afterClosed().subscribe(result => {
      console.log(result);
    });
  }

  getMessages(chat) {
    this.chatsService.getMessages(chat.id).subscribe((result: any[]) => {
      this.messages = result;
    });
  }
}
