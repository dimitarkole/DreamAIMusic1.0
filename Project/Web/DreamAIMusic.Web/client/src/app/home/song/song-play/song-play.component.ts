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

@Component({
  selector: 'app-song-play',
  templateUrl: './song-play.component.html',
  styleUrls: ['./song-play.component.css']
})
export class SongPlayComponent implements OnInit {
  songId: string;
  song: Song;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private categoryService: CategoryService,
    private songService: SongService) {
  }

  ngOnInit() {
    this.song = this.route.snapshot.data.song;
    this.songId = this.song.id;
  }
}
