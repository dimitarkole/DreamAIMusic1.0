import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { PlaylistService } from '../services/playlist.service';
import Playlist from '../../components/shared/models/playlist';

@Injectable({
  providedIn: 'root'
})
export class PlaylistResolver implements Resolve<Playlist> {
  constructor(private playlistService: PlaylistService) { }

  resolve(route: ActivatedRouteSnapshot): Observable<Playlist> {
    let id = route.params['id'];
    return this.playlistService.getById(id);
  }
}
