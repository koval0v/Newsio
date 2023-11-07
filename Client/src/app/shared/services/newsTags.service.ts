import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { INews } from '../models/INews.model';
import { INewsTag, ISaveNewsTag } from '../models/INewsTag.model';

@Injectable({
  providedIn: 'root'
})
export class NewsTagsService {
  constructor(private _http: HttpClient) { }

    get(): Observable<INewsTag[]>{
      return this._http.get<INewsTag[]>(environment.urlPrefix + environment.newsTagsUrl);
    }

    create(newsTag: ISaveNewsTag) {
      return this._http.post<INewsTag>(environment.urlPrefix + environment.newsTagsUrl, newsTag);
    } 

    getById(id: number): Observable<INewsTag> {
      return this._http.get<INewsTag>(environment.urlPrefix + environment.newsTagsUrl + `/${id}`);
    }

    deleteByNewsAndTagId(newsTag: ISaveNewsTag) {
      return this._http.post<INewsTag>(environment.urlPrefix + environment.newsUrl + "/deleteByIds", newsTag);
    } 
}
