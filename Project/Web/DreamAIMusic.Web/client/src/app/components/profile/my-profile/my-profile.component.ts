import { Component, OnInit } from '@angular/core';
import User from '../../shared/models/user';
import { FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ProfileService } from '../../../core/services/profile.service';
import { Observable } from 'rxjs';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ProfileEditComponent } from '../profile-edit/profile-edit.component';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.css']
})
export class MyProfileComponent implements OnInit {
  user: User;
  userId: string;
  constructor(private modalService: NgbModal,
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private profileService: ProfileService) {

    this.profileService.MyProfile().subscribe(data => {
      this.user = data;
      this.userId = data.id;
    })

  }

  ngOnInit() {
  }

  openEdit() {
    let modal = this.modalService.open(ProfileEditComponent);
    console.log(this.user);

    modal.componentInstance.user = this.user;
    modal.result.then(_ => {
      this.router.navigate(['/myProfile']);
    }).catch(err => {
      console.log(err);
    })
  }
}
