import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GamesComponent } from './games.component';
import { FeedsViewComponent } from './pages/feeds-view/feeds-view.component';
import { NewsDetailComponent } from './pages/feeds-view/news-detail/news-detail.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';

const routes: Routes = [
  { path: 'news/channel', component: GamesComponent, children: [
    { path: '', component: FeedsViewComponent },
    { path: 'feed/:feedId/games/:newsId', component: NewsDetailComponent },
    { path: '404', component: NotFoundComponent }
    // { path: '**', redirectTo: '/404'}
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GamesRoutingModule { }
