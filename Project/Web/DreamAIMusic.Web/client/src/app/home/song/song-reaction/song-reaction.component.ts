import { Song } from '../../../components/shared/models/song';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { SongService } from '../../../core/services/song.service';
import { Reaction } from '../../../components/shared/models/reaction';
import { Component, OnInit, Input } from '@angular/core';
import { SongReactionService } from '../../../core/services/song-reaction.service';
import { ReactionInfo } from '../../../components/shared/models/reactionInfo';

@Component({
  selector: 'app-song-reaction',
  templateUrl: './song-reaction.component.html',
  styleUrls: ['./song-reaction.component.css']
})
export class SongReactionComponent implements OnInit {
  @Input() song: Song
  reactionForm: FormGroup;
  reaction: ReactionInfo;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private songReactionService: SongReactionService) {
  }

  ngOnInit(): void {
    this.setReaction();
    this.reactionForm = this.formBuilder.group({
      songId: this.song.id,
      reaction: null,
    });
  }

  likeSong() {
    this.reactionForm.get('reaction').setValue(Reaction.Like);
    let reaction: Song = this.reactionForm.value;
    reaction.reaction = Reaction.Like;
    this.songReactionService.reactionSong(reaction)
      .subscribe(_ => {
        this.song.countLikes++;
        this.setReaction();
      });
  }

  dislikeSong() {
    this.reactionForm.get('reaction').setValue(Reaction.Dislike);
    let reaction: Song = this.reactionForm.value;
    reaction.reaction = Reaction.Dislike;
    this.songReactionService.reactionSong(reaction)
      .subscribe(_ => {
        this.song.countDislikes++;
        this.setReaction();
      });
  }

  unReactionSong(id: string, oldReacton: string) {
    this.songReactionService.delete(id)
      .subscribe(_ => {
        this.reaction.reaction = Reaction.None;
        if (oldReacton == "like") {
          this.song.countLikes--;
        }
        else if (oldReacton == "dislike") {
          this.song.countDislikes--;
        }
        this.setReaction();
      });
  }

  unLikeSong(id: string) {
    this.reactionForm.get('reaction').setValue(Reaction.Dislike);
    let reaction: Song = this.reactionForm.value;
    reaction.reaction = Reaction.Dislike;
    this.songReactionService.edit(reaction, id)
      .subscribe(_ => {
        this.song.countDislikes++;
        this.song.countLikes--;
        this.setReaction();
      });
  }

  unDislikeSong(id: string) {
    this.reactionForm.get('reaction').setValue(Reaction.Dislike);
    let reaction: Song = this.reactionForm.value;
    reaction.reaction = Reaction.Like;

    this.songReactionService.edit(reaction, id)
      .subscribe(_ => {
        this.song.countLikes++;
        this.song.countDislikes--;
        this.setReaction();
      });
  }

  get songIdGet(): string {
    return this.song.id;
  }

  setReaction() {
    this.songReactionService.isReactedSong(this.songIdGet).subscribe(data => {
      this.reaction = data
    });
  }
}
