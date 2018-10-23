import { GamesNewsModel } from './games-news.model';

export class PageNewsModel {
  constructor(
    public TotalCount: number,
    public TotalPage: number,
    public PrevPage: string,
    public NextPage: string,
    public Values: Array<GamesNewsModel>
  ) {}
}
