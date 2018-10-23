export class GamesNewsModel {
  constructor(
    public Id?: number,
    public Title?: string,
    public Description?: string,
    public Author?: string,
    public Categories?: string,
    public Enclosure?: string,
    public Guid?: string,
    public PublishingDate?: Date
  ) {}
}
