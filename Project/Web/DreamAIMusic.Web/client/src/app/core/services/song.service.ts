import { Injectable } from '@angular/core';
import { HttpClient, HttpEventType } from '@angular/common/http';
import { Song } from '../../components/shared/models/song';

@Injectable({
  providedIn: 'root'
})
export class SongService {
  private routeSongController: string = 'Song';
  private routeHomeController: string = 'Home';

  constructor(private http: HttpClient) { }
  
  all() {
    return this.http.get<Song[]>(this.routeHomeController);
  }

  allOwn() {
    return this.http.get<Song[]>(this.routeSongController);
  }

  create(song: Song) {
    return this.http.post(this.routeSongController, song, { reportProgress: true, observe: 'events' });
  }

  getById(id: number) {
    return this.http.get<Song>(`${this.routeHomeController}/${id}`);
  }

  edit(song: Song) {
    return this.http.put(`${this.routeSongController}/${song.id}`, song);
  }

  delete(id: number) {
    return this.http.delete(`${this.routeSongController}/${id}`);
  }

  uploadImage(files) {
    if (files.length === 0) {
      return;
    }

    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    return this.http.post(`${this.routeSongController}/UploadImage`,
      formData, { reportProgress: true, observe: 'events' });
  }
}
