import { Component, OnInit, Input } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';
import { globalConstants } from '../../../../common/global-constants';
import getPage from '../../../../common/paginator';
import { CommentService } from '../../../../core/services/comment.service';

@Component({
  selector: 'app-comment-list',
  templateUrl: './comment-list.component.html',
  styleUrls: ['./comment-list.component.css']
})
export class CommentListComponent implements OnInit  {
  @Input() allComments: Array<Comment>
  page: number = globalConstants.pagination.defaultPage;
  collectionSize: number;
  private itemsPerPage: number;
  comments: Comment[] = [];
 
  constructor(private modalService: NgbModal,
    private commentService: CommentService,
    private router: Router) {
    this.itemsPerPage = globalConstants.pagination.itemsPerPage;
  }

  ngOnInit() {
    this.getCommentsPerPage(this.page)
  }

  public getCommentsPerPage(page: number): void {
    this.comments = getPage<Comment>(this.allCommentsGet, page, this.itemsPerPage);
  }

  get allCommentsGet(): Array<Comment> {
    return this.allComments;
  }
}
