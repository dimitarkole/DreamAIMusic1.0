import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import Category from '../../../components/shared/models/category';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Song } from '../../../components/shared/models/song';
import { CategoryService } from '../../../core/services/category.service';
import { SongService } from '../../../core/services/song.service';
import { HttpEventType } from '@angular/common/http';
import { Reaction } from '../../../components/shared/models/reaction';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PlaylistAddSongComponent } from '../../../components/user/playlist/playlist-add-song/playlist-add-song.component';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-song-play',
  templateUrl: './song-play.component.html',
  styleUrls: ['./song-play.component.css']
})
export class SongPlayComponent implements OnInit {
  isAuth: boolean = false;

  songId: string;
  song: Song;

  constructor(
    private modalService: NgbModal,
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private categoryService: CategoryService,
    private songService: SongService,
    public authService: AuthService) {
    this.isAuth = authService.isAuth;
    this.authService.isAuthChanged.subscribe(() => {
      this.isAuth = this.authService.isAuth;
    })
  }

  ngOnInit() {
    this.song = this.route.snapshot.data.song;
    this.songId = this.song.id;
  }

  openAddToSong() {
    let modal = this.modalService.open(PlaylistAddSongComponent);
    modal.componentInstance.song = this.song;
    modal.result.then(_ => {
    }).catch(err => {
      console.log(err);
    })
  }
}
