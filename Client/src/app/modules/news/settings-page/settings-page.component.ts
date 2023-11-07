import { Component, OnInit } from '@angular/core';
import { Form, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IUserChangePassword } from 'src/app/shared/models/IUser.model';
import { NotificationsService } from 'src/app/shared/services/notifications.service';
import { UsersService } from 'src/app/shared/services/users.service';

@Component({
  selector: 'app-settings-page',
  templateUrl: './settings-page.component.html',
  styleUrls: ['./settings-page.component.css']
})
export class SettingsPageComponent implements OnInit {

  passwordData: IUserChangePassword = {} as IUserChangePassword;

  constructor(private router: Router, private usersService: UsersService, private route: ActivatedRoute,
    private notificationsService: NotificationsService) { }

  ngOnInit(): void {
  }

  redirectToAllNews() {
    this.router.navigateByUrl("news-page/all");
  }

  submit(form: NgForm) {
    this.route.params.subscribe(params => {
      this.usersService.changePassword(params["id"], form.value).subscribe(res => {
        if (res) {
          this.notificationsService.showSuccessMessage("Password was successfully changed!");
        } else {
          this.notificationsService.showSuccessMessage("Something went wrong! Maybe previous password is incorrect!");
        }
      });
   });
  }
}
