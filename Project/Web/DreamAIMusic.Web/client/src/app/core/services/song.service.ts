import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
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

  create(category: Song) {
    return this.http.post(this.routeSongController, category);
  }

  getById(id: number) {
    return this.http.get<Song>(`${this.routeHomeController}/${id}`);
  }

  edit(category: Song) {
    return this.http.put(`${this.routeSongController}/${category.id}`, category);
  }

  delete(id: number) {
    return this.http.delete(`${this.routeSongController}/${id}`);
  }
}
