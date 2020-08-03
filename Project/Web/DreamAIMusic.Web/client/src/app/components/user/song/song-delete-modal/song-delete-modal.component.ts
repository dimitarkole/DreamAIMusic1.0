import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-song-delete-modal',
  templateUrl: './song-delete-modal.component.html',
  styleUrls: ['./song-delete-modal.component.css']
})
export class SongDeleteModalComponent {
  constructor(public modal: NgbActiveModal) {
  }
}
