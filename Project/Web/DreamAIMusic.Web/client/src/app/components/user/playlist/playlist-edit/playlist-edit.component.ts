import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import Playlist from '../../../shared/models/playlist';
import { PlaylistService } from '../../../../core/services/playlist.service';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-playlist-edit',
  templateUrl: './playlist-edit.component.html',
  styleUrls: ['./playlist-edit.component.css']
})
export class PlaylistEditComponent implements OnInit {
  playlist: Playlist;
  nameMinLength = 2;
  nameMaxLength = 30;
  playlistForm: FormGroup
  public progress: number;
  public message: string;
  private routeUpload: string = 'song/Upload';
  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    public modal: NgbActiveModal,
    public playlistService: PlaylistService) {
  }

  ngOnInit() {
    this.playlistForm = this.formBuilder.group({
      id: this.playlist.id,
      name: [
        this.playlist.name,
        [
          Validators.required,
          Validators.minLength(this.nameMinLength),
          Validators.maxLength(this.nameMaxLength)
        ]
      ],
    })
  }

  OnSubmit() {
    let playlist: Playlist = this.playlistForm.value;

    this.playlistService.edit(playlist)
      .subscribe(_ => {
        this.modal.close(); //It closes successfully
      })
  }

  get name(): AbstractControl {
    return this.playlistForm.get('name');
  }

}
