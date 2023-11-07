import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { INews } from 'src/app/shared/models/INews.model';
import { NewsService } from 'src/app/shared/services/news.service';
import { SectionsService } from 'src/app/shared/services/sections.service';

@Component({
  selector: 'app-news-item',
  templateUrl: './news-item.component.html',
  styleUrls: ['./news-item.component.css']
})
export class NewsItemComponent implements OnInit {

  @Input() news: INews = {} as INews;

  @Input() myNews: boolean = false;

  constructor(private router: Router, private newsService: NewsService) {}

  ngOnInit(): void {
  }

  redirectToMore(id: number) {
    this.router.navigateByUrl(`news-page/more/${id}`);
  }

  redirectToEdit(id: number) {
    this.router.navigateByUrl(`manage-news/edit/${id}`);
  }

  deleteNews(id: number) {
    this.newsService.delete(id).subscribe();
    window.location.reload();
  }
}
