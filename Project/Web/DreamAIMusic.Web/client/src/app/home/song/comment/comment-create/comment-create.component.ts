import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { modelConstants } from '../../../../common/model-constants';
import { Router } from '@angular/router';
import Comment from '../../../../components/shared/models/comment';
import { CommentService } from '../../../../core/services/comment.service';

@Component({
  selector: 'app-comment-create',
  templateUrl: './comment-create.component.html',
  styleUrls: ['./comment-create.component.css']
})
export class CommentCreateComponent implements OnInit {
  @Input() songId: string
  commentForm: FormGroup
  commentMinLength = modelConstants.comment.textMinLength
  commentMaxLength = modelConstants.comment.textMaxLength
  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private commentService: CommentService) {
  }

  ngOnInit() {
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

  formHandler() {
    let comment: Comment = this.commentForm.value;
    comment.songId = this.songId;

    this.commentService.create(comment)
      .subscribe(_ => {
        this.router.navigate(['']);
      })

    this.commentForm.reset();
  }

  get text(): AbstractControl {
    return this.commentForm.get('text');
  }
}
