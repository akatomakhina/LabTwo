import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { NewsRoutingModule } from './news-routing.module';
import { NewsComponent } from './news.component';

import { FormsModule } from '../../../node_modules/@angular/forms';
import { HttpClientModule } from '../../../node_modules/@angular/common/http';
import { NotificationsService } from '../../../node_modules/angular2-notifications';
import { GamesModule } from './games/games.module';


@NgModule({
  imports: [
    NgbModule,
    CommonModule,
    NewsRoutingModule,
    FormsModule,
    HttpClientModule,
    GamesModule,
  ],
  declarations: [
    NewsComponent
  ]
})
export class NewsModule { }
