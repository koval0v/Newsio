import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ILocalUser } from '../../models/IUser.model';
import { LocalStorageService } from '../../services/storage.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  currentUser: ILocalUser;

  constructor(private router: Router, private storageService: LocalStorageService) {}

  ngOnInit(): void {
    this.currentUser = this.storageService.getCurrentUserFromStorage();
    console.log(this.currentUser);
  }
  
  redirectToAllNews() {
    this.router.navigateByUrl("news-page/all");
  }

  redirectToMyNews() {
    this.router.navigateByUrl(`news-page/all/${this.currentUser.id}`);
  }

  redirectToSettings() {
    this.router.navigateByUrl(`news-page/settings/${this.currentUser.id}`);
  }

  redirectToNewNews() {
    if (this.currentUser) {
      this.router.navigateByUrl("manage-news/create");
    } else {
      this.router.navigateByUrl("auth/sign-up");
    }
  }

  logOut() {
    this.storageService.deleteUserFromStorage();
    window.location.reload();
  }

}
