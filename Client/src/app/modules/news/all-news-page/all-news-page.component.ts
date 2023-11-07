import { Statement } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { INews } from 'src/app/shared/models/INews.model';
import { ISection } from 'src/app/shared/models/ISection.model';
import { ITag } from 'src/app/shared/models/ITag.model';
import { ILocalUser } from 'src/app/shared/models/IUser.model';
import { NewsService } from 'src/app/shared/services/news.service';
import { SectionsService } from 'src/app/shared/services/sections.service';
import { LocalStorageService } from 'src/app/shared/services/storage.service';
import { TagsService } from 'src/app/shared/services/tags.service';
import { UsersService } from 'src/app/shared/services/users.service';

@Component({
  selector: 'all-news-page',
  templateUrl: './all-news-page.component.html',
  styleUrls: ['./all-news-page.component.css']
})
export class AllNewsPageComponent implements OnInit{

    allNews: INews[] = [];

    myNews: boolean = false;

    author: ILocalUser;

    sections: ISection[] = [];

    tags: ITag[] = [];

    allNewsTemp: INews[] = [];

    startDate: Date;

    endDate: Date;

    constructor(private newsService: NewsService, private route: ActivatedRoute,
      private storageService: LocalStorageService, private usersService: UsersService,
      private sectionsService: SectionsService, private tagsService: TagsService) {}

    ngOnInit(): void {
      this.route.params.subscribe(params => {
        if (params['id']) {
          if (this.storageService.getCurrentUserFromStorage().id == params['id']) {
            this.myNews = true;
          } else {
            this.usersService.getById(params['id']).subscribe(res => this.author = res);
          }
          this.newsService.getByAuthorId(params['id']).subscribe(res => this.allNews = res);
        } else {
          this.newsService.get().subscribe(res => this.allNews = res);
        }
     });

     this.newsService.get().subscribe(res => this.allNewsTemp = res);

     this.sectionsService.get().subscribe(res => this.sections = res);

     this.tagsService.get().subscribe(res => this.tags = res);
    }

  changeSectionFilter(section: any) {
    if (section == 0) {
      this.allNews = this.allNewsTemp;
    } else {
      this.allNews = this.allNewsTemp.filter(p => p.sectionId == section);
    }
  }

  changeTagFilter(tagIds: number[]) {
    if (!tagIds.length) {
      this.allNews = this.allNewsTemp;
    } else {
      this.allNews = this.allNewsTemp.filter(p => tagIds.every(element => {
        return p.tags.map(x => x.id).indexOf(element) !== -1;
      }));
    }
  }

  changeDateFilter(date: any, start: boolean) {
    if (start) {
      this.startDate = new Date(date);
    } else {
      this.endDate = new Date(date);
    }

    this.allNews = this.allNewsTemp.filter(p => new Date(p.createdDate) >= this.startDate
      && new Date(p.createdDate) <= this.endDate);
  }
}
