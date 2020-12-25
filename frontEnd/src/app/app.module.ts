import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import {PostService} from 'src/app/services/post.service';
import { DataTablesModule } from 'angular-datatables';
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    DataTablesModule
  ],
  providers: [PostService],
  bootstrap: [AppComponent]
})
export class AppModule { }
