import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/index';
import { FeedRequest } from '../models/feed-request.model';
import { environment } from '../../../../../environments/environment';
import { FeedModel } from '../models/feed.model';

@Injectable({
  providedIn: 'root'
})
export class FeedsService {
  private url = environment.apiUrl + 'api/channel';

  constructor(private  http: HttpClient) {}

  requestFeed(url: string): Observable<number> {
    return this.http.post<number> (`${this.url}`, new FeedRequest(url));
  }

  getFeeds(): Observable<Array<FeedModel>> {
    return this.http.get<Array<FeedModel>>(this.url);
  }
}
