import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import Playlist from '../../components/shared/models/playlist';
import { Song } from '../../components/shared/models/song';

@Injectable({
  providedIn: 'root'
})
export class PlaylistService {

  private route: string = 'Playlist';

  constructor(private http: HttpClient) { }

  all() {
    return this.http.get<Playlist[]>(this.route);
  }

  GetOwn() {
    return this.http.get<Playlist[]>(`${this.route}/GetOwn`);
  }

  GetOwnForAddingSong(songId: string) {
    return this.http.get<Playlist[]>(`${this.route}/GetOwnForAddingSong/${songId}`);
  }


  create(playlist: Playlist) {
    return this.http.post(this.route, playlist);
  }

  getById(id: string) {
    return this.http.get<Playlist>(`${this.route}/${id}`);
  }

  edit(playlist: Playlist) {
    return this.http.put(`${this.route}/${playlist.id}`, playlist);
  }

  delete(id: string) {
    return this.http.delete(`${this.route}/${id}`);
  }

  addSong(playlist: Playlist) {
    return this.http.post(`${this.route}/AddSongToPlaylist`, playlist);;
  }
}
