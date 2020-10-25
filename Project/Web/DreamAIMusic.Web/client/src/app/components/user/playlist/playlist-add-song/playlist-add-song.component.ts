import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, AbstractControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { PlaylistService } from '../../../../core/services/playlist.service';
import { Song } from '../../../shared/models/song';
import Playlist from '../../../shared/models/playlist';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-playlist-add-song',
  templateUrl: './playlist-add-song.component.html',
  styleUrls: ['./playlist-add-song.component.css']
})
export class PlaylistAddSongComponent implements OnInit {
  @Input() song: Song;

  playlists: Observable<Playlist[]>

  nameMinLength = 2;
  nameMaxLength = 30;
  playlistForm: FormGroup
  public progress: number;
  public message: string;
  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    public modal: NgbActiveModal,
    public playlistService: PlaylistService) {
  }

  ngOnInit() {
    this.playlists = this.playlistService.GetOwnForAddingSong(this.song.id);

    this.playlistForm = this.formBuilder.group({
      playlistId: [
        'default',
        [
          Validators.required,
          Validators.pattern('^((?!default).)*$'),
        ]
      ],
      songId: this.song.id,
    })
  }

  OnSubmit() {
    let addSongToPlaylist: Playlist = this.playlistForm.value;
    console.log(addSongToPlaylist);
    this.playlistService.addSong(addSongToPlaylist)
      .subscribe(_ => {
        this.modal.close(); //It closes successfully
      })
  }

  get playlistId(): AbstractControl {
    return this.playlistForm.get('playlistId');
  }
}
