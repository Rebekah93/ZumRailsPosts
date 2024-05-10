import { Component } from '@angular/core';
import { PostService } from './services/post.service';
import { Post } from '../models/post';
import {HttpErrorResponse} from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Posts';

  constructor(private postService: PostService) {}
  posts: Post[] = [];
  tag: string;
  selectedOptionsSortBy = '';
  selectedOptionsDirection = '';

  ngOnInit(): void {
    this.postService
      .GetPosts(this.tag, this.selectedOptionsSortBy, this.selectedOptionsDirection)
      .subscribe((result: Post[]) => (this.posts = result)),
      (error: HttpErrorResponse) => {
        console.error('An error occurred:', error.message);
      };
  }
   
  onSelectedSortBy(value:string): void {
		this.selectedOptionsSortBy = value;
	}
  onSelectedDirection(value: string) {
    this.selectedOptionsDirection = value;
  }
}
