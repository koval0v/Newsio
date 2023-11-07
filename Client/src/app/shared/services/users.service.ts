import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { INews } from '../models/INews.model';
import { ISection } from '../models/ISection.model';
import { ITag } from '../models/ITag.model';
import { ILoginUser, IUser, IUserChangePassword } from '../models/IUser.model';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  constructor(private _http: HttpClient) { }

    get(): Observable<IUser[]>{
      return this._http.get<IUser[]>(environment.urlPrefix + environment.usersUrl);
    }

    create(tag: IUser) {
      return this._http.post<IUser>(environment.urlPrefix + environment.usersUrl, tag);
    } 

    getById(id: number): Observable<IUser> {
      return this._http.get<IUser>(environment.urlPrefix + environment.usersUrl + `/${id}`);
    }

    loginExists(login: string): Observable<boolean> {
      return this._http.get<boolean>(environment.urlPrefix + environment.usersUrl + `/username/${login}`);
    }

    getLoginUser(loginUser: ILoginUser): Observable<IUser> {
      return this._http.post<IUser>(environment.urlPrefix + environment.usersUrl + "/login", loginUser);
    }

    changePassword(id: number, changePasswordUser: IUserChangePassword) {
      return this._http.put<boolean>(environment.urlPrefix + environment.usersUrl
        + `/password/${id}`, changePasswordUser);
    }
}