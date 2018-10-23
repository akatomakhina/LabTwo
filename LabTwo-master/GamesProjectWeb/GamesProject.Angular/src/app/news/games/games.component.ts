import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FeedsService } from './shared/services/feeds.service';
import { FeedModel } from './shared/models/feed.model';

@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls:  ['./games.component.scss'],
  encapsulation: ViewEncapsulation.None
})

export class GamesComponent implements OnInit {
  feeds: FeedModel[] = [];
  isLoaded = false;
  searchRequest: string;
  constructor(private router: Router,
              private route: ActivatedRoute,
              private  feedsService: FeedsService) { }

  ngOnInit() {
    this.searchRequest = '';
    this.feedsService.getFeeds()
      .subscribe(feeds => {
        this.feeds = feeds;
        this.isLoaded = true;
      });
  }
}
