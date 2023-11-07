import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { HeaderModule } from 'src/app/shared/header/header.module';
import { NewsRoutingModule } from './news-routing.module';
import { NewsPageComponent } from './news-page/news-page.component';
import { NewsItemComponent } from './news-item/news-item.component';
import { AllNewsPageComponent } from './all-news-page/all-news-page.component';
import { MorePageComponent } from './more-page/more-page.component';
import { SettingsPageComponent } from './settings-page/settings-page.component';
import { FormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';

@NgModule({
  declarations: [
    NewsPageComponent,
    NewsItemComponent,
    AllNewsPageComponent,
    MorePageComponent,
    SettingsPageComponent
  ],
  imports: [
    CommonModule,
    NewsRoutingModule,
    HttpClientModule,
    HeaderModule,
    FormsModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
  ],
  providers: [],
})
export class NewsModule { }
