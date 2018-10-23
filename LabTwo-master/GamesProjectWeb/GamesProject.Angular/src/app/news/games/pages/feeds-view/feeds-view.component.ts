import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Params, Router } from '@angular/router';
import { FeedsService } from '../../shared/services/feeds.service';
import { GamesNewsService } from '../../shared/services/games-news.service';
import { fadeStateTrigger } from '../../shared/animations/fade.animation';
import { Message } from '../../shared/models/message.model';
import { GamesNewsModel } from '../../shared/models/games-news.model';
import {PageNewsModel} from "../../shared/models/page-news.model";

@Component({
  selector: 'app-feeds-view',
  templateUrl: './feeds-view.component.html',
  styleUrls: ['./feeds-view.component.scss'],
  animations: [fadeStateTrigger]
})

export class FeedsViewComponent implements OnInit {

  feedId: number;
  searchStr: string;
  message: Message;
  isLoaded = true;
  isDataLoaded = false;
  isPaginationNeed = false;
  isSearch = false;
  news: GamesNewsModel[] = [];
  pageModel: PageNewsModel;
  currentPage = 0;
  constructor(private router: Router,
              private route: ActivatedRoute,
              private  feedsService: FeedsService,
              private  newsService: GamesNewsService) { }

  ngOnInit() {
    this.searchStr = '';
    this.message = new Message('danger', '');
    this.route.queryParams
      .subscribe((params: Params) => {
          if (params['newsSource']) {
            this.isSearch = false;
            this.searchStr = params['newsSource'];
            if (params['page']) {
              this.currentPage = +params['page'];
              this.getFeed(this.searchStr, this.currentPage);
            }
          } else if (params['searchRequest']) {
            this.isSearch = true;
            this.currentPage = +params['page'];
            this.searchNewsByTitle(params['searchRequest']);
          }
        }
      );
  }

  public handleSearch() {
    this.router.navigate([], {
      queryParams: {
        newsSource: this.searchStr,
        page: this.currentPage
      },
      relativeTo: this.route
    });
  }

  public openDetail(news: GamesNewsModel) {
    this.router.navigate(['./feed', this.feedId, 'games', news.Id], {
        relativeTo: this.route,
        queryParams: {
          parentRoute: this.searchStr,
          parentPage: this.currentPage
        }
      });
  }

  private searchNewsByTitle(title: string) {
    this.isLoaded = false;
    this.isDataLoaded = false;
    this.isPaginationNeed = false;
    this.newsService.searchNewsByTitle(title)
      .subscribe(resp => {
        this.news = resp;
        if (this.news.length === 0) {
          this.showMessage({
            text: 'Nothing found.',
            type: 'success'
          });
        }
        this.isLoaded = true;
        this.isDataLoaded = true;

      },
        error => {
          this.showMessage({
            text: 'Bad request',
            type: 'warning'
          });
          this.isLoaded = true;
        });
  }

  private getFeed(url: string, page: number = 0) {
    this.isLoaded = false;
    this.isDataLoaded = false;
    this.feedsService.requestFeed(url)
      .subscribe(
        resp => {
          this.feedId = resp;
          this.newsService.getNewsPage(this.feedId, page)
            .subscribe(
              pageModel => {
                this.pageModel = pageModel;
                this.news = pageModel.Values;
                this.isLoaded = true;
                this.isDataLoaded = true;
                this.isPaginationNeed = true;
              }
            );
        },
        error => {
          this.showMessage({
            text: 'Resource not found',
            type: 'warning'
          });
          this.isLoaded = true;
        }
      );
  }
  private navigateTo(source: string = this.searchStr, page: number = this.currentPage) {
    if (page >= 0 && page < this.pageModel.TotalPage) {
      this.router.navigate([], {
        queryParams: {
          newsSource: source,
          page: page
        },
        relativeTo: this.route
      });
    }
  }

  private showMessage(message: Message) {
    this.message = message;
    window.setTimeout( () => {
      this.message.text = '';
    }, 5000);
  }
}
