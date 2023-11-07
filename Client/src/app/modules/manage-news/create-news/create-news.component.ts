import { Component, EventEmitter, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { fromEvent } from 'rxjs';
import { INews, ISaveNews, IUpdateNews } from 'src/app/shared/models/INews.model';
import { ISaveNewsTag } from 'src/app/shared/models/INewsTag.model';
import { ISection } from 'src/app/shared/models/ISection.model';
import { ITag } from 'src/app/shared/models/ITag.model';
import { NewsService } from 'src/app/shared/services/news.service';
import { NewsTagsService } from 'src/app/shared/services/newsTags.service';
import { NotificationsService } from 'src/app/shared/services/notifications.service';
import { SectionsService } from 'src/app/shared/services/sections.service';
import { LocalStorageService } from 'src/app/shared/services/storage.service';
import { TagsService } from 'src/app/shared/services/tags.service';

@Component({
  selector: 'app-create-news',
  templateUrl: './create-news.component.html',
  styleUrls: ['./create-news.component.css']
})
export class CreateNewsComponent implements OnInit {

  @Input() news: INews = {} as INews;

  sections: ISection[] = [];

  tags: ITag[] = [];

  tagsOfNews: ITag[] = [];

  tagsOfNewsTemp: ITag[] = [];

  private id: number;

  constructor(private router: Router, private route: ActivatedRoute, private sectionsService: SectionsService,
    private newsService: NewsService, private newsTagsService: NewsTagsService, private tagsService: TagsService,
    private storageService: LocalStorageService, private notificationsService: NotificationsService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = params['id'];
      if (params['id']) {
        this.newsService.getById(params['id']).subscribe(res => {
          this.tagsOfNews = res.tags;
          this.tagsOfNewsTemp = res.tags;
        });
      }
    });

    this.sectionsService.get().subscribe(res => {
      this.sections = res;
      if (!this.news.sectionId) {
        this.news.sectionId = this.sections[0].id;
      }
    });

    this.tagsService.get().subscribe(res => {
      this.tags = res;
    });
  }

  submit(form: NgForm) {
    const addTags: ITag[] = this.tagsOfNews.filter(x => this.tagsOfNewsTemp.some(y => y === x));

    const deleteTags: ITag[] = this.tagsOfNewsTemp.filter(x => !this.tagsOfNews.some(y => y === x));

    console.log(addTags);
    console.log(deleteTags);

    if (this.isEditRoute()) {
      var newsUpdate: IUpdateNews = { title: form.value["title"], description: form.value["description"],
      createdDate: new Date(this.news.createdDate).toJSON(), updatedDate: new Date().toJSON(), sectionId: form.value["sectionId"] as number,
      authorId: this.storageService.getCurrentUserFromStorage().id, id: this.news.id };

      this.newsService.update(this.news.id, newsUpdate)
      .subscribe((res) => {
        this.notificationsService.showSuccessMessage("News was successfully updated!");
        addTags.forEach(element => {
          var newsTag: ISaveNewsTag = { newsId: this.id, tagId: element.id };
          this.newsTagsService.create(newsTag).subscribe();
        });
        deleteTags.forEach(element => {
          var newsTag: ISaveNewsTag = { newsId: this.id, tagId: element.id };
          this.newsTagsService.deleteByNewsAndTagId(newsTag).subscribe();
        });
      });
    } else {
      var newsSave: ISaveNews = { title: form.value["title"], description: form.value["description"], createdDate: new Date().toJSON(),
      updatedDate: new Date().toJSON(), sectionId: form.value["sectionId"] as number,
      authorId: this.storageService.getCurrentUserFromStorage().id };

      this.newsService.create(newsSave)
      .subscribe((res) => {
        this.notificationsService.showSuccessMessage("News was successfully added!");
        this.redirectToAllNews();
        this.tagsOfNews.forEach(element => {
          const newsTag: ISaveNewsTag = { newsId: res.id, tagId: element.id };
          this.newsTagsService.create(newsTag).subscribe();
        });
      });
    }
  }

  addTagForNews(tag: ITag) {
    if (this.tagsOfNews.some(x => x.id == tag.id)) {
      this.tagsOfNews = this.tagsOfNews.filter(p => p.id != tag.id);
    } else {
      this.tagsOfNews.push(tag);
    }
  }

  getTagStyle(tag: ITag) {
    if (this.tagsOfNews.some(x => x.id == tag.id)) {
      return {'background-color':'#2F47A5', 'border-color':'#2F47A5', 'color':'white'};
    } else {
      return {'background-color':'white'};
    }
  }

  redirectToAllNews() {
    this.router.navigateByUrl("news-page/all");
  }

  redirectToMore() {
    this.router.navigateByUrl(`news-page/more/${this.news.id}`);
  }

  isEditRoute() {
    return this.router.url.includes("edit");
  }
}
