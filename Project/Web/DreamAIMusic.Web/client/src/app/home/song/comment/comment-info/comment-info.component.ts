import { Component, OnInit, Input } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';
import Comment from '../../../../components/shared/models/comment';
import { CommentService } from '../../../../core/services/comment.service';
import CommentLike from '../../../../components/shared/models/commentLike';
import CommentDislike from '../../../../components/shared/models/commentDislike';
import { AbstractControl } from '@angular/forms';
import { AuthService } from '../../../../core/services/auth.service';

@Component({
  selector: 'app-comment-info',
  templateUrl: './comment-info.component.html',
  styleUrls: ['./comment-info.component.css']
})
export class CommentInfoComponent implements OnInit {
  @Input() comment: Comment
  isAuth: boolean = false;

  constructor(private modalService: NgbModal,
    private router: Router,
    private commentService: CommentService,
    public authService: AuthService) {
    this.isAuth = authService.isAuth;
    this.authService.isAuthChanged.subscribe(() => {
      this.isAuth = this.authService.isAuth;
    })
  }

  ngOnInit(): void {
    console.log(this.comment);
  }
}
