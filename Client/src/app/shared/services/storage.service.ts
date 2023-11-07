import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { INews } from '../models/INews.model';
import { INewsTag, ISaveNewsTag } from '../models/INewsTag.model';
import { ILocalUser, IUser } from '../models/IUser.model';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {
  constructor() { }

    getCurrentUserFromStorage(): ILocalUser {
        return JSON.parse(localStorage.getItem('currentUser') as string);
    }

    addUserInStorage(user: ILocalUser) {
        localStorage.setItem('currentUser', JSON.stringify(user));
    }

    deleteUserFromStorage() {
        localStorage.removeItem("currentUser");
    }
}
