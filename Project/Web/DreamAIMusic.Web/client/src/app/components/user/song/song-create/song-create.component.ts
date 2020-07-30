import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { SongService } from '../../../../core/services/song.service';
import { Song } from '../../../shared/models/song';
import Category from '../../../shared/models/category';
import { Observable } from 'rxjs';
import { CategoryService } from '../../../../core/services/category.service';

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
      path: [
        null,
        [
          Validators.required
        ]
      ],
      musicCategoryId: [
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
    let category: Song = this.songForm.value;

    this.songService.create(category)
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

  get musicCategoryId(): AbstractControl {
    return this.songForm.get('musicCategoryId');
  }
  
}
