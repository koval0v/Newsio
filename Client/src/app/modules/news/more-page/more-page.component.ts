import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { INews } from 'src/app/shared/models/INews.model';
import { NewsService } from 'src/app/shared/services/news.service';

@Component({
  selector: 'more-page',
  templateUrl: './more-page.component.html',
  styleUrls: ['./more-page.component.css']
})
export class MorePageComponent implements OnInit {

  news: INews = {} as INews;

  constructor(private router: Router, private route: ActivatedRoute, private newsService: NewsService) {
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.newsService.getById(params['id']).subscribe(res => {
        this.news = res;
      });
   });
  }
  
  redirectToAllNews() {
    this.router.navigateByUrl("news-page/all");
  }

  redirectToAuthorNews() {
    this.router.navigateByUrl(`news-page/all/${this.news.authorId}`);
  }

}
