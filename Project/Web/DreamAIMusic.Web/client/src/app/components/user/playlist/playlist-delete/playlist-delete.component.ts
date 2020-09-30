import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-playlist-delete',
  templateUrl: './playlist-delete.component.html',
  styleUrls: ['./playlist-delete.component.css']
})
export class PlaylistDeleteComponent{
  constructor(public modal: NgbActiveModal) {
  }
}
