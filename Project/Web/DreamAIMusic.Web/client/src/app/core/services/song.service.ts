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

  create(song: Song, fileToUpload: File) {
    // upload image
    return this.http.post(this.routeSongController, song, { reportProgress: true, observe: 'events' });
    // create song
   
  }

  getById (id: string){
    return this.http.get<Song>(`${this.routeHomeController}/${id}`);
  }

  edit(song: Song, id: string) {
    return this.http.put(`${this.routeSongController}/${id}`, song);
  }

  delete(id: string) {
    return this.http.delete(`${this.routeSongController}/${id}`);
  }

  postFile(fileToUpload: File, songName: string) {
     const formData: FormData = new FormData();
     formData.append('image', fileToUpload, fileToUpload.name);
     formData.append('songName', songName);
    return this.http
      .post(`${this.routeSongController}/uploadImage`, formData);
  }
}
