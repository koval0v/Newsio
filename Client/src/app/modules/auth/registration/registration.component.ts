import { Component, EventEmitter, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { INews } from 'src/app/shared/models/INews.model';
import { ISection } from 'src/app/shared/models/ISection.model';
import { ILoginUser, IUser } from 'src/app/shared/models/IUser.model';
import { NotificationsService } from 'src/app/shared/services/notifications.service';
import { UsersService } from 'src/app/shared/services/users.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  user: IUser = {} as IUser;

  constructor(private router: Router, private usersService: UsersService,
    private notificationsService: NotificationsService) { }

  ngOnInit(): void {
  }

  submit(form: NgForm) {
    this.usersService.loginExists(form.value["username"]).subscribe((res) => {
      if (res) {
        this.notificationsService.showErrorMessage("User with this username already exists. Please try again!");
      } else {
        this.usersService.create(form.value).subscribe(res => {
          this.notificationsService.showSuccessMessage("User was successfully signed up!");
          this.redirectToSignIn();
        });
      }
    })
  }

  redirectToAllNews() {
    this.router.navigateByUrl("news-page/all");
  }

  redirectToSignIn() {
    this.router.navigateByUrl("auth/sign-in");
  }

  isLoginRoute() {
    return this.router.url.includes("sign-in");
  }
}
