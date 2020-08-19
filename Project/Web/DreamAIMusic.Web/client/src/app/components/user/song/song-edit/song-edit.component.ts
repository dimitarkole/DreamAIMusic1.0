import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { Observable } from 'rxjs';
import Category from '../../../shared/models/category';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { CategoryService } from '../../../../core/services/category.service';
import { SongService } from '../../../../core/services/song.service';
import { Song } from '../../../shared/models/song';
import { HttpEventType } from '@angular/common/http';

@Component({
  selector: 'app-song-edit',
  templateUrl: './song-edit.component.html',
  styleUrls: ['./song-edit.component.css']
})
export class SongEditComponent implements OnInit {
  songId: string;
  categories$: Observable<Category[]>
  nameMinLength = 2;
  nameMaxLength = 30;
  textMinLength = 10;
  textMaxLength = 1000;
  songForm: FormGroup
  public progress: number;
  public message: string;
  private routeUpload: string = 'song/Upload';
  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private categoryService: CategoryService,
    private songService: SongService) {
    this.categories$ = categoryService.all();
  }

  ngOnInit() {
    let song: Song = this.route.snapshot.data.song;
    this.songId = song.id;
    this.songForm = this.formBuilder.group({
      id: song.id,
      name: [
        song.name,
        [
          Validators.required,
          Validators.minLength(this.nameMinLength),
          Validators.maxLength(this.nameMaxLength)
        ]
      ],
      imageFile: [
        song.imageFile,
        [
          // Validators.required
        ]
      ],
      path: [
        song.path,
        [
          // Validators.required
        ]
      ],
      songCategoryId: [
        song.songCategoryId,
        [
          Validators.required,
          Validators.pattern('^((?!default).)*$'),
        ]
      ],
      text: [
        song.text,
        [
          Validators.required,
          Validators.minLength(this.textMinLength),
          Validators.maxLength(this.textMaxLength)
        ]
      ]
    })
  }

  formHandler() {
    let song: Song = this.songForm.value;
    this.songService.edit(song, this.songId)
      .subscribe(_ => {
        this.router.navigate(['song', 'all']);
      })

    this.songForm.reset();
  }

  get name(): AbstractControl {
    return this.songForm.get('name');
  }

  get path(): AbstractControl {
    return this.songForm.get('path');
  }

  get text(): AbstractControl {
    return this.songForm.get('text');
  }

  get songCategoryId(): AbstractControl {
    return this.songForm.get('songCategoryId');
  }

  get imageFile(): AbstractControl {
    return this.songForm.get('imageFile');
  }
}
