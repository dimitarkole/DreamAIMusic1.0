import { Component, OnInit, Input } from '@angular/core';
import { Song } from '../../../shared/models/song';
import { globalConstants } from '../../../../common/global-constants';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { SongService } from '../../../../core/services/song.service';
import { Router } from '@angular/router';
import getPage from '../../../../common/paginator';
import { SongDeleteModalComponent } from '../song-delete-modal/song-delete-modal.component';

@Component({
  selector: 'app-song-list',
  templateUrl: './song-list.component.html',
  styleUrls: ['./song-list.component.css']
})
export class SongListComponent{
  @Input() categoty: Song

  page: number = globalConstants.pagination.defaultPage;
  collectionSize: number;
  private itemsPerPage: number;
  song: Song[] = [];
  allSongs: Song[] = [];

  constructor(private modalService: NgbModal,
    private songService: SongService,
    private router: Router) {
    this.itemsPerPage = globalConstants.pagination.itemsPerPage;
    this.songService.allOwn().subscribe(data => {
      this.allSongs = data;
      this.getSongsPerPage(this.page);
    })
  }

  openDelete(songId: number) {
    let modal = this.modalService.open(SongDeleteModalComponent);
    modal.result.then(value => {
      this.songService.delete(songId).subscribe(_ => {
          this.router.navigate(['/song']);
        })
    }).catch(err => {
      console.log(err);
    })
  }

  public getSongsPerPage(page: number): void {
    this.song = getPage<Song>(this.allSongs, page, this.itemsPerPage);
  }
}
