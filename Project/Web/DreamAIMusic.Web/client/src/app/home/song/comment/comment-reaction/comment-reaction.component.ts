import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ReactionInfo } from '../../../../components/shared/models/reactionInfo';
import { ActivatedRoute, Router } from '@angular/router';
import { CommentReactionService } from '../../../../core/services/comment-reaction.service';
import Comment from '../../../../components/shared/models/comment';
import { Reaction } from '../../../../components/shared/models/reaction';

@Component({
  selector: 'app-comment-reaction',
  templateUrl: './comment-reaction.component.html',
  styleUrls: ['./comment-reaction.component.css']
})
export class CommentReactionComponent implements OnInit {

  @Input() comment: Comment
  reactionForm: FormGroup;
  reaction: ReactionInfo;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private commentReactionService: CommentReactionService) {
  }

  ngOnInit(): void {
    this.setReaction();
    this.reactionForm = this.formBuilder.group({
      commentId: this.comment.id,
      reaction: null,
    });
  }

  likeComment() {
    this.reactionForm.get('reaction').setValue(Reaction.Like);
    let reaction: Comment = this.reactionForm.value;
    reaction.reaction = Reaction.Like;
    this.commentReactionService.reactionComment(reaction)
      .subscribe(_ => {
        this.comment.likesCount++;
        this.setReaction();
      });
  }

  dislikeComment() {
    this.reactionForm.get('reaction').setValue(Reaction.Dislike);
    let reaction: Comment = this.reactionForm.value;
    reaction.reaction = Reaction.Dislike;
    this.commentReactionService.reactionComment(reaction)
      .subscribe(_ => {
        this.comment.dislikesCount++;
        this.setReaction();
      });
  }

  unReactionComment(id: string, oldReacton: string) {
    this.commentReactionService.delete(id)
      .subscribe(_ => {
        this.reaction.reaction = Reaction.None;
        if (oldReacton == "like") {
          this.comment.likesCount--;
        }
        else if (oldReacton == "dislike") {
          this.comment.dislikesCount--;
        }
        this.setReaction();
      });
  }

  unLikeComment(id: string) {
    this.reactionForm.get('reaction').setValue(Reaction.Dislike);
    let reaction: Comment = this.reactionForm.value;
    reaction.reaction = Reaction.Dislike;
    this.commentReactionService.edit(reaction, id)
      .subscribe(_ => {
        this.comment.dislikesCount++;
        this.comment.likesCount--;
        this.setReaction();
      });
  }

  unDislikeComment(id: string) {
    this.reactionForm.get('reaction').setValue(Reaction.Dislike);
    let reaction: Comment = this.reactionForm.value;
    reaction.reaction = Reaction.Like;

    this.commentReactionService.edit(reaction, id)
      .subscribe(_ => {
        this.comment.likesCount++;
        this.comment.dislikesCount--;
        this.setReaction();
      });
  }
  
  get commentIdGet(): string {
    return this.comment.id;
  }

  setReaction() {
    this.commentReactionService.isReactedComment(this.commentIdGet).subscribe(data => {
      this.reaction = data
    });
  }
}
