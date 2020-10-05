import { Component, Input } from '@angular/core';
import { Song } from '../components/shared/models/song';
import { globalConstants } from '../common/global-constants';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { SongService } from '../core/services/song.service';
import { Router } from '@angular/router';
import getPage from '../common/paginator';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  page: number = globalConstants.pagination.defaultPage;
  collectionSize: number;
  private itemsPerPage: number;
  songs: Song[] = [];
  allSongs: Song[] = [];

  constructor(private modalService: NgbModal,
    private songService: SongService,
    private router: Router) {
    this.itemsPerPage = globalConstants.pagination.itemsPerPage;
    this.songService.all().subscribe(data => {
      this.allSongs = data;
      this.getSongsPerPage(this.page);
    })
  }

  public getSongsPerPage(page: number): void {
    this.songs = getPage<Song>(this.allSongs, page, this.itemsPerPage);
  }
}
