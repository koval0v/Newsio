import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { HeaderModule } from 'src/app/shared/header/header.module';
import { CreateNewsComponent } from './create-news/create-news.component';
import { ManageNewsRoutingModule } from './manage-news-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EditNewsComponent } from './edit-news/edit-news.component';

@NgModule({
  declarations: [
    CreateNewsComponent,
    EditNewsComponent,
  ],
  imports: [
    CommonModule,
    ManageNewsRoutingModule,
    HttpClientModule,
    HeaderModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [],
})
export class ManageNewsModule { }
