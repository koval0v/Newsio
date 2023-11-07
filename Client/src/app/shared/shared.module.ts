import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SharedRoutingModule } from './shared-routing.module';
import {MatDialogModule} from '@angular/material/dialog';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';


@NgModule({
  declarations: [
  ],
  imports: [
    BrowserModule,
    CommonModule,
    SharedRoutingModule,
    MatDialogModule,
    FormsModule,
    ReactiveFormsModule,
  ],
})
export class SharedModule { }
