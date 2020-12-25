import { Injectable } from '@angular/core';
import {Post} from '../models/Post';
import { Subject,Observable } from 'rxjs';

import { HttpClient,HttpParams } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class PostService {
  myData: Post[];
  constructor(public httpClient: HttpClient) { }
  private readonly API_URL='http://localhost:33660/api/feedback/allpost';
  getPosts(): Observable<any>{
    
    let params = new HttpParams().set('skip', '0');
    params = params.append('take', '5'); 
      return this.httpClient.get<any>(this.API_URL,{params:params})
  }
}
