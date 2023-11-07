import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { INews } from '../models/INews.model';
import { ISection } from '../models/ISection.model';
import { ITag } from '../models/ITag.model';

@Injectable({
  providedIn: 'root'
})
export class TagsService {
  constructor(private _http: HttpClient) { }

    get(): Observable<ITag[]>{
      return this._http.get<ITag[]>(environment.urlPrefix + environment.tagsUrl);
    }

    create(tag: ITag) {
      return this._http.post<ITag>(environment.urlPrefix + environment.tagsUrl, tag);
    } 

    getById(id: number): Observable<ITag> {
      return this._http.get<ITag>(environment.urlPrefix + environment.tagsUrl + `/${id}`);
    }
}