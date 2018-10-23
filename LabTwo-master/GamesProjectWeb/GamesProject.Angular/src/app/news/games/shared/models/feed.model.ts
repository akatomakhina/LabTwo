export class FeedModel {
  constructor(
    public Id: number,
    public Title?: string,
    public Link?: string,
    public LinkRss?: string,
    public Description?: string,
    public LastModified?: Date
  ) {}
}
