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
  mp3Url: string = "/assets/images/app.jpg";

  imageFileToUpload: File = null;
  mp3FileToUpload: File = null;

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
    //console.log(this.categories$);
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
      ],
      imageExtension: [
        null,
        [
          //Validators.required,
        ]
      ],
      mp3Extension: [
        null,
        [
          //Validators.required,
        ]
      ],
      uniqueSongFilesName: [
        null
      ],
    })
  }

  formHandler() {
    this.songService.postFile(this.imageFileToUpload, this.mp3FileToUpload, this.name.value).subscribe(
      (data) => {
        console.log(data);
        this.songForm.get('uniqueSongFilesName').setValue(data["uniqueSongFilesName"]);
        this.songForm.get('imageExtension').setValue(data["imageExtension"]);
        this.songForm.get('mp3Extension').setValue(data["mp3Extension"]);

        let song: Song = this.songForm.value;
        this.songService.create(song, this.imageFileToUpload)
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
  
  get ImageExtension(): AbstractControl {
    return this.songForm.get('imageExtension');
  }

  get Mp3Extension(): AbstractControl{
    return this.songForm.get('mp3Extension');
  }

  handleImageFileInput(file: FileList) {
    this.imageFileToUpload = file.item(0);

    //Show image preview
    var reader = new FileReader();
    reader.onload = (event: any) => {
      this.imageUrl = event.target.result;
      this.songForm.get('imageExtension').setValue(event.target.result);
    }
    reader.readAsDataURL(this.imageFileToUpload);
  }

  handleMP3FileInput(file: FileList) {
    this.mp3FileToUpload = file.item(0);

    //Show image preview
    var reader = new FileReader();
    reader.onload = (event: any) => {
      this.mp3Url = event.target.result;
      this.songForm.get('mp3Extension').setValue(event.target.result);
    }
    reader.readAsDataURL(this.mp3FileToUpload);
  }
}
