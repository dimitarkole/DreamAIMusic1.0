import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import Comment from '../../components/shared/models/comment';
import CommentLike from '../../components/shared/models/commentLike';
import CommentDislike from '../../components/shared/models/commentDislike';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  private routeCommentController: string = 'comments';
  private routeCommentLikeController: string = 'commentLike';
  private routeCommentDislikeController: string = 'commentDislike';
  constructor(private http: HttpClient) { }

  getById(id: string) {
    return this.http.get<Comment>(`${this.routeCommentController}/${id}`);
  }

  getBySongId(id: string) {
    return this.http.get<Comment[]>(`${this.routeCommentController}/${id}`);
  }

  create(comment: Comment) {
    return this.http.post(this.routeCommentController+'/post', comment);
  }

  createChildrenComment(comment: Comment) {
    return this.http.post(this.routeCommentController + '/postChildrenCommentar', comment);
  }

  edit(comment: Comment) {
    return this.http.put(`${this.routeCommentController}/${comment.id}`, comment);
  }

  delete(id: number) {
    return this.http.delete(`${this.routeCommentController}/${id}`);
  }

  likeComment(commentLike: CommentLike) {
    return this.http.post(this.routeCommentLikeController, {"commentId" : commentLike.commentId});
  }

  dislikeComment(commentDislike: CommentDislike) {
    return this.http.post(this.routeCommentDislikeController, commentDislike);
  }
}
