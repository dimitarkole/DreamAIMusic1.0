import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Song } from '../../components/shared/models/song';
import { Reaction } from '../../components/shared/models/reaction';
import { ReactionInfo } from '../../components/shared/models/reactionInfo';

@Injectable({
  providedIn: 'root'
})
export class SongReactionService {
  private route: string = 'SongReaction';

  constructor(private http: HttpClient) { }

  reactionSong(reaction: Song) {
    return this.http.post(this.route, reaction);
  }

  isReactedSong(songId: string) {
    return this.http.get<ReactionInfo>(`${this.route}/${songId}`);
  }

  delete(id: string) {
    return this.http.delete(`${this.route}/${id}`);
  }

  edit(song: Song, id: string) {
    return this.http.put(`${this.route}/${id}`, song);
  }
}
