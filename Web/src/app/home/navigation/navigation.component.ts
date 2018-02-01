import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../login/login.service';
import { LocalStorageConst } from '../../_consts/local-storage.const';

@Component({
  selector: 'navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit {

  role: string;

  constructor(private loginService: LoginService) { }

  ngOnInit() {
    this.role = localStorage.getItem(LocalStorageConst.ROLE_NAME).toLocaleLowerCase();
  }

  logout() {
    this.loginService.signOut();
  }

}
