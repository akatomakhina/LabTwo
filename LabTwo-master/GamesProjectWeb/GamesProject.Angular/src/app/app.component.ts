import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'news-aggregator';
  public options = {
    position: ['bottom', 'right'],
    timeOut : 3000,
    lastOnBottom : true,
    clickToClose : true,
    animate : 'scale'
  };
}
