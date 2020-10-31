import { Component, OnInit, Input } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';
import { globalConstants } from '../../../../common/global-constants';
import getPage from '../../../../common/paginator';
import { CommentService } from '../../../../core/services/comment.service';
import { Song } from '../../../../components/shared/models/song';
import Comment from '../../../../components/shared/models/comment';
import { Validators, FormGroup, FormBuilder, AbstractControl } from '@angular/forms';
import { modelConstants } from '../../../../common/model-constants';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-comment-list',
  templateUrl: './comment-list.component.html',
  styleUrls: ['./comment-list.component.css']
})
export class CommentListComponent implements OnInit  {
  @Input() song: Song;

  allComments: Array<Comment>;
  page: number = globalConstants.pagination.defaultPage;
  collectionSize: number;
  private itemsPerPage: number;
  comments: Comment[] = [];
  commentForm: FormGroup;
  commentMinLength = modelConstants.comment.textMinLength;
  commentMaxLength = modelConstants.comment.textMaxLength;

  constructor(private modalService: NgbModal,
    private commentService: CommentService,
    private formBuilder: FormBuilder,
    private router: Router) {
    this.itemsPerPage = globalConstants.pagination.itemsPerPage;
  }

  ngOnInit() {
    this.allComments = this.song.comments;
    this.getCommentsPerPage(this.page)
    {
      this.commentForm = this.formBuilder.group({
        text: [
          null,
          [
            Validators.required,
            Validators.minLength(this.commentMinLength),
            Validators.maxLength(this.commentMaxLength)
          ]
        ]
      })
    }
  }

  formHandler() {
    let comment: Comment = this.commentForm.value;
    comment.songId = this.song.id;

    this.commentService.create(comment)
      .subscribe(_ => {
        this.getComments();
      });
    
    this.commentForm.reset();
  }

  getComments() {
    this.commentService.getBySongId(this.song.id).subscribe(data => {
      console.log(data);
      this.allComments = data;
    });
  }

  public getCommentsPerPage(page: number): void {
    this.comments = getPage<Comment>(this.allCommentsGet, page, this.itemsPerPage);
  }

  get allCommentsGet(): Array<Comment> {
     return this.allComments;
  }

  get text(): AbstractControl {
    return this.commentForm.get('text');
  }
}
