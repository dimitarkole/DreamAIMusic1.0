import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { SongService } from '../../../../core/services/song.service';
import { Song } from '../../../shared/models/song';
import Category from '../../../shared/models/category';
import { Observable } from 'rxjs';
import { CategoryService } from '../../../../core/services/category.service';
import { HttpEventType, HttpRequest, HttpClient } from '@angular/common/http';

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
  songForm: FormGroup;
  public progress: number;
  public message: string;

  imageUrl: string = "/assets/images/app.jpg";
  fileToUpload: File = null;

  error: string;
  userId: number = 1;
  uploadResponse = { status: '', message: '', filePath: '' };
  @Output() public onUploadFinished = new EventEmitter();

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private categoryService: CategoryService,
    private songService: SongService,
    private http: HttpClient)
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
      imagePath: [
        null,
        [
         Validators.required
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
    this.songService.postFile(this.fileToUpload, this.name.value).subscribe(
      (data) => {
        this.songForm.get('imagePath').setValue(data["imagePath"]);
        console.log(data["imagePath"])
        console.log(this.imagePath.value);
        console.log(this.songForm)

        let song: Song = this.songForm.value;
        this.songService.create(song, this.fileToUpload)
          .subscribe(_ => {
            this.router.navigate(['song', 'own']);
            this.songForm.reset();

          });
      });


   
  }

  get name(): AbstractControl {
    return this.songForm.get('name');
  }

  get text(): AbstractControl {
    return this.songForm.get('text');
  }

  get songCategoryId(): AbstractControl {
    return this.songForm.get('songCategoryId');
  }

  get imagePath(): AbstractControl {
    return this.songForm.get('imagePath');
  }


  handleFileInput(file: FileList) {
    this.fileToUpload = file.item(0);

    //Show image preview
    var reader = new FileReader();
    reader.onload = (event: any) => {
      this.imageUrl = event.target.result;
      this.songForm.get('imagePath').setValue(event.target.result);

    }
    reader.readAsDataURL(this.fileToUpload);
  }

  onFileChange(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.songForm.get('imagePath').setValue(file);
    }
  }
}
