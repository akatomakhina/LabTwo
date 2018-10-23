import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { GamesRoutingModule } from './games-routing.module';
import { GamesComponent } from './games.component';
import { FeedsViewComponent } from './pages/feeds-view/feeds-view.component';
import { FeedsService } from './shared/services/feeds.service';
import { GamesNewsService } from './shared/services/games-news.service';
import { MomentPipe } from './shared/pipes/moment.pipe';
import { HtmlFilterPipe } from './shared/pipes/html-filter.pipe';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatInputModule } from '@angular/material/input';
import {
  MatButtonModule, MatCardModule, MatIconModule, MatListModule, MatProgressSpinnerModule,
  MatSidenavModule
} from '@angular/material';
import { FooterComponent } from './shared/components/footer/footer.component';
import { NewsDetailComponent } from './pages/feeds-view/news-detail/news-detail.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';



@NgModule({
  imports: [
    NgbModule,
    FormsModule,
    CommonModule,
    GamesRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatToolbarModule,
    MatInputModule,
    MatProgressSpinnerModule,
    MatSidenavModule,
    MatCardModule,
    MatListModule,
    MatIconModule
  ],
  declarations: [
    GamesComponent,
    FeedsViewComponent,
    FooterComponent,
    MomentPipe,
    HtmlFilterPipe,
    NewsDetailComponent,
    NotFoundComponent
  ],
  providers: [
    FeedsService,
    GamesNewsService
  ],
  exports: [
    MatButtonModule,
    MatToolbarModule,
    MatInputModule,
    MatProgressSpinnerModule,
    MatSidenavModule,
    MatCardModule,
    MatListModule,
    MatIconModule
  ]
})
export class GamesModule { }
