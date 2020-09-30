import { Component, OnInit, Input } from '@angular/core';
import { globalConstants } from '../../../../common/global-constants';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import Playlist from '../../../shared/models/playlist';
import { PlaylistService } from '../../../../core/services/playlist.service';
import { Router } from '@angular/router';
import getPage from '../../../../common/paginator';
import { PlaylistCreateComponent } from '../playlist-create/playlist-create.component';
import { PlaylistEditComponent } from '../playlist-edit/playlist-edit.component';

@Component({
  selector: 'app-playlist-list',
  templateUrl: './playlist-list.component.html',
  styleUrls: ['./playlist-list.component.css']
})
export class PlaylistListComponent {

  page: number = globalConstants.pagination.defaultPage;
  collectionSize: number;
  private itemsPerPage: number;
  playlists: Playlist[] = [];
  allPlaylists: Playlist[] = [];

  constructor(private modalService: NgbModal,
    private playlistService: PlaylistService,
    private router: Router) {
    this.itemsPerPage = globalConstants.pagination.itemsPerPage;
    this.playlistService.GetOwn().subscribe(data => {
      this.allPlaylists = data;
      console.log(data);
      this.getPlaylistsPerPage(this.page);
    })
  }

  openDelete(playlistId: string) {
    /*let modal = this.modalService.open(PlaylistDeleteModalComponent);
    modal.result.then(value => {
      this.playlistService.delete(playlistId).subscribe(_ => {
        this.router.navigate(['/song']);
      })
    }).catch(err => {
      console.log(err);
    })*/
  }

  openEdit(playlist: Playlist) {
    let modal = this.modalService.open(PlaylistEditComponent);

    modal.componentInstance.playlist = playlist;
    modal.result.then(_ => {
      this.router.navigate(['/playlist/own']);
    }).catch(err => {
      console.log(err);
    })
  }

  openCreate() {
    let modal = this.modalService.open(PlaylistCreateComponent);

    modal.result.then(_ => {
      this.router.navigate(['/playlist/own']);
    }).catch(err => {
      console.log(err);
    })
  }

 /* openEdit(song: Playlist) {
    this.router.navigate(['/song/edit', song.id]);
  }*/

  public getPlaylistsPerPage(page: number): void {
    this.playlists = getPage<Playlist>(this.allPlaylists, page, this.itemsPerPage);
  }

}
