import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { INews, ISaveNews, IUpdateNews } from '../models/INews.model';

@Injectable({
  providedIn: 'root'
})
export class NewsService {
  constructor(private _http: HttpClient) { }

    get(): Observable<INews[]>{
      return this._http.get<INews[]>(environment.urlPrefix + environment.newsUrl);
    }

    create(news: ISaveNews) {
      return this._http.post<INews>(environment.urlPrefix + environment.newsUrl, news);
    } 

    update(id: number, news: IUpdateNews) {
      return this._http.put<INews>(environment.urlPrefix + environment.newsUrl + `/${id}`, news);
    } 

    delete(id: number) {
      return this._http.delete(environment.urlPrefix + environment.newsUrl + `/${id}`);
    } 

    getById(id: number): Observable<INews> {
      return this._http.get<INews>(environment.urlPrefix + environment.newsUrl + `/${id}`);
    }

    getByAuthorId(id: number): Observable<INews[]> {
      return this._http.get<INews[]>(environment.urlPrefix + environment.newsUrl + `/author/${id}`);
    }
}
