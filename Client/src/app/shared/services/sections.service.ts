import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { INews } from '../models/INews.model';
import { ISection } from '../models/ISection.model';

@Injectable({
  providedIn: 'root'
})
export class SectionsService {
  constructor(private _http: HttpClient) { }

    get(): Observable<ISection[]>{
      return this._http.get<ISection[]>(environment.urlPrefix + environment.sectionsUrl);
    }

    create(section: ISection) {
      return this._http.post<ISection>(environment.urlPrefix + environment.sectionsUrl, section);
    } 

    getById(id: number): Observable<ISection> {
      return this._http.get<ISection>(environment.urlPrefix + environment.sectionsUrl + `/${id}`);
    }
}
