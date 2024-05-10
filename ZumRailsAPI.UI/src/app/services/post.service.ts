import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Post } from '../../models/post';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  url = '/Post';
  constructor(private http: HttpClient) { }

  public GetPosts(tag:string, sortBy:string, direction:string) : Observable<Post[]>
  {
    const postParams = new HttpParams();
    const passedParams = [tag, sortBy, direction];
    passedParams.forEach((item: any) => {
      postParams.append('param', item);
    });
    return this.http.get<Post[]>( `${environment.apiUrl}${this.url}`, {params: postParams});
  }
}
