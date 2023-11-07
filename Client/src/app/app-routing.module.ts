import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [{
  path: '',
  redirectTo: 'news-page',
  pathMatch: 'full',
  },
  {
    path: 'news-page',
    loadChildren: () => import('./modules/news/news.module').then((m) => m.NewsModule),
  },
  {
    path: 'manage-news',
    loadChildren: () => import('./modules/manage-news/manage-news.module').then((m) => m.ManageNewsModule),
  },
  {
    path: 'auth',
    loadChildren: () => import('./modules/auth/auth.module').then((m) => m.AuthModule),
  },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
