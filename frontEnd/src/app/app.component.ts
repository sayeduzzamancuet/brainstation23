import { Component, OnDestroy, OnInit } from '@angular/core';
import { DataTablesModule } from 'angular-datatables';
import { PostService } from './services/post.service';
import {Post} from '../app/models/Post';

import { Subject } from 'rxjs';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnDestroy, OnInit {
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject<any>();

  constructor(private postService: PostService) { }
  posts : Post[]
  ngOnInit(): void {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 2
    };
    
     
    this.postService.getPosts().subscribe(data=>{
        this.posts=data;
    });
  }

  ngOnDestroy(): void {
   
  }
}
 
