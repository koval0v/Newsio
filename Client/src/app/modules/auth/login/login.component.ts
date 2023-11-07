import { Component, EventEmitter, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { INews } from 'src/app/shared/models/INews.model';
import { ISection } from 'src/app/shared/models/ISection.model';
import { ILocalUser, ILoginUser, IUser } from 'src/app/shared/models/IUser.model';
import { NotificationsService } from 'src/app/shared/services/notifications.service';
import { LocalStorageService } from 'src/app/shared/services/storage.service';
import { UsersService } from 'src/app/shared/services/users.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user: IUser = {} as IUser;
  
  constructor(private router: Router, private notificationsService: NotificationsService,
    private usersService: UsersService, private storageService: LocalStorageService) { }

  ngOnInit(): void {
  }

  submit(form: NgForm) {
    var loginUser: ILoginUser = { userName: form.value["username"], password: form.value["password"] };

    this.usersService.getLoginUser(loginUser).subscribe((res) => {
      if (res) {
        var localUser: ILocalUser = { id: res.id, userName: res.userName };
        this.storageService.addUserInStorage(localUser);
        this.notificationsService.showSuccessMessage("User was successfully signed in!");
        this.redirectToAllNews();
      } else {
        this.notificationsService.showErrorMessage("Incorrect username or password. Please try again!");
      }
    })
  }

  redirectToAllNews() {
    this.router.navigateByUrl("news-page/all");
  }

  redirectToSignUp() {
    this.router.navigateByUrl("auth/sign-up");
  }

  isLoginRoute() {
    return this.router.url.includes("sign-in");
  }
}
