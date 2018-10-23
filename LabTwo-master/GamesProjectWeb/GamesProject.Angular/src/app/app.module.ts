import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MATERIAL_SANITY_CHECKS } from '@angular/material/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NewsModule } from './news/news.module';
import { HomeComponent } from './home/home.component';
import { NotificationsService, SimpleNotificationsModule } from '../../node_modules/angular2-notifications';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent
  ],
  imports: [
    NgbModule.forRoot(),
    BrowserModule,
    AppRoutingModule,
    NewsModule,
    SimpleNotificationsModule.forRoot(),
    BrowserAnimationsModule
  ],
  providers: [
    { provide: MATERIAL_SANITY_CHECKS, useValue: false }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
