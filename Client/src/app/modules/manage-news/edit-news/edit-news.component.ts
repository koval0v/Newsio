import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { INews } from 'src/app/shared/models/INews.model';
import { NewsService } from 'src/app/shared/services/news.service';

@Component({
  selector: 'app-edit-news',
  templateUrl: './edit-news.component.html',
  styleUrls: ['./edit-news.component.css']
})
export class EditNewsComponent implements OnInit {
  news: INews;

  id: number;
  
  constructor(private route: ActivatedRoute, private newsService: NewsService) {
    this.route.params.subscribe(params => {
      this.newsService.getById(params['id']).subscribe(res => this.news = res);
   }); 
  }

  ngOnInit(): void {
  }
}
