import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { SongService } from '../../../../core/services/song.service';
import { Song } from '../../../shared/models/song';
import Category from '../../../shared/models/category';
import { Observable } from 'rxjs';
import { CategoryService } from '../../../../core/services/category.service';
import { HttpEventType } from '@angular/common/http';

@Component({
  selector: 'app-song-create',
  templateUrl: './song-create.component.html',
  styleUrls: ['./song-create.component.css']
})
export class SongCreateComponent implements OnInit {
  categories$: Observable<Category[]>
  nameMinLength = 2;
  nameMaxLength = 30;
  textMinLength = 10;
  textMaxLength = 1000;
  songForm: FormGroup
  public progress: number;
  public message: string;
  private routeUpload: string = 'song/Upload';

  @Output() public onUploadFinished = new EventEmitter();

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private categoryService: CategoryService,
    private songService: SongService)
  {
    this.categories$ = categoryService.all();
  }

  ngOnInit() {
    this.songForm = this.formBuilder.group({
      name: [
        null,
        [
          Validators.required,
          Validators.minLength(this.nameMinLength),
          Validators.maxLength(this.nameMaxLength)
        ]
      ],
      imageFile: [
        null,
        [
         // Validators.required
        ]
      ],
      path: [
        null,
        [
         // Validators.required
        ]
      ],
      songCategoryId: [
        'default',
        [
          Validators.required,
          Validators.pattern('^((?!default).)*$'),
        ]
      ],
      text: [
        null,
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
    console.log(song);
    this.songService.create(song)
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

  public uploadImage = (files) => {
    this.songService.uploadImage(files).subscribe(event => {
        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          this.onUploadFinished.emit(event.body);
         // this.songForm.controls['imageFile'].setValue(event.ok);
        }
    });
  }
}
