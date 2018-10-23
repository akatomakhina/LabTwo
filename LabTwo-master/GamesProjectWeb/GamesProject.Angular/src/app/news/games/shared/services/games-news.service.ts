import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/index';
import { environment } from '../../../../../environments/environment';
import { GamesNewsModel } from '../models/games-news.model';
import { PageNewsModel } from '../models/page-news.model';

@Injectable({
  providedIn: 'root'
})
export class GamesNewsService {
  private url = environment.apiUrl + 'api/channel';

  constructor(private  http: HttpClient) {}

  public getNews(feedId: number): Observable<Array<GamesNewsModel>> {
    return this.http.get<Array<GamesNewsModel>>(`${this.url}${feedId}/games`);
  }

  public getNewsById(feedId: number, gameId: number): Observable<GamesNewsModel> {
    return this.http.get<GamesNewsModel>(`${this.url}/${feedId}/games/${gameId}`);
  }

  public getNewsPage(feedId: number, page: number = 0): Observable<PageNewsModel> {
    let params = new HttpParams();
    params = params.append('page', page.toString());
    return this.http.get<PageNewsModel>(`${this.url}/${feedId}/games/page`, {params: params});
  }

  public searchNewsByTitle(title: string): Observable<Array<GamesNewsModel>> {
    return this.http.get<Array<GamesNewsModel>>(`${this.url}/title/${title}`);
  }
}
