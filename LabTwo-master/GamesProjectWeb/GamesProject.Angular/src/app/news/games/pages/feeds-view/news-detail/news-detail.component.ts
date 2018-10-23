import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { GamesNewsService } from '../../../shared/services/games-news.service';
import { GamesNewsModel } from '../../../shared/models/games-news.model';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

@Component({
  selector: 'app-news-detail',
  templateUrl: './news-detail.component.html',
  styleUrls: ['./news-detail.component.scss']
})
export class NewsDetailComponent implements OnInit {

  isLoaded = false;
  feedId: number;
  newsId: number;
  news: GamesNewsModel;
  content: SafeHtml;
  parentRoute: string;
  parentPage: number;
  returnMessage = 'Back to games news';
  constructor(private route: ActivatedRoute,
              private router: Router,
              private newsService: GamesNewsService,
              private sanitizer: DomSanitizer) { }
  ngOnInit() {
    this.parentRoute = '';
    this.feedId = +this.route.snapshot.paramMap.get('feedId');
    this.newsId = +this.route.snapshot.paramMap.get('newsId');
    this.newsService.getNewsById(this.feedId, this.newsId)
      .subscribe(
        newsResponse => {
          this.news = newsResponse;
          this.isLoaded = true;
          this.content = this.sanitizer.bypassSecurityTrustHtml(this.news.Description);
        }
        , error => {
          this.router.navigate(['/news/channel/404']);
        }
      );
    this.route.queryParams
      .subscribe((params: Params) => {
          if (params['parentRoute']) {
            this.parentRoute = params['parentRoute'];
            this.returnMessage += ' on ' + this.parentRoute;
          }
          if (params['parentPage']) {
            this.parentPage = +params['parentPage'];
          }
        }
      );
  }

  handleReturn() {
    this.router.navigate(['/news/channel'], {
      queryParams: {
        newsSource: this.parentRoute,
        page: this.parentPage
      }
    });
  }

}
