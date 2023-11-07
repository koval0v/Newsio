import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardService as AuthGuard } from 'src/app/shared/guards/auth.guard';
import { CreateNewsComponent } from './create-news/create-news.component';
import { EditNewsComponent } from './edit-news/edit-news.component';

const routes: Routes = [
  {
    path: 'create',
    component: CreateNewsComponent,
  },
  {
    path: 'edit/:id',
    component: EditNewsComponent,
  },
  {
    path: '**',
    redirectTo: 'create',
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ManageNewsRoutingModule { }
