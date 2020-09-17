import { Component, OnInit, Input } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';
import Comment from '../../../../components/shared/models/comment';
import { CommentService } from '../../../../core/services/comment.service';
import CommentLike from '../../../../components/shared/models/commentLike';
import CommentDislike from '../../../../components/shared/models/commentDislike';
import { AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-comment-info',
  templateUrl: './comment-info.component.html',
  styleUrls: ['./comment-info.component.css']
})
export class CommentInfoComponent {
  @Input() comment: Comment
  constructor(private modalService: NgbModal,
    private router: Router,
    private commentService: CommentService) { }

  likeComment(commentId: string) {
    let commentLike: CommentLike = {
      commentId : commentId,
    }
    this.commentService.likeComment(commentLike)
      .subscribe(_ => {
      this.router.navigate(['']);
    })
  }

  dislikeComment(commentId: string) {
    let commentDislike: CommentDislike = {
      commentId: commentId,
    }
    this.commentService.dislikeComment(commentDislike)
      .subscribe(_ => {
        this.router.navigate(['']);
      })
  }
}
