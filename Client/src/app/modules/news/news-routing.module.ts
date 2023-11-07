import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllNewsPageComponent } from './all-news-page/all-news-page.component';
import { MorePageComponent } from './more-page/more-page.component';
import { NewsPageComponent } from './news-page/news-page.component';
import { SettingsPageComponent } from './settings-page/settings-page.component';

const routes: Routes = [
  {
      path: '',
      component: NewsPageComponent,
      children: [
          {
            path: 'all',
            component: AllNewsPageComponent,
          },
          {
            path: 'all/:id',
            component: AllNewsPageComponent,
          },
          {
            path: 'more/:id',
            component: MorePageComponent,
          },
          {
            path: 'settings/:id',
            component: SettingsPageComponent,
          },
          {
            path: '**',
            redirectTo: 'all',
          },
      ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NewsRoutingModule { }
