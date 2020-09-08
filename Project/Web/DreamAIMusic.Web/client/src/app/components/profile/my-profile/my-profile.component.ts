import { Component, OnInit } from '@angular/core';
import User from '../../shared/models/user';
import { FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ProfileService } from '../../../core/services/profile.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.css']
})
export class MyProfileComponent implements OnInit {
  user: User;
  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private profileService: ProfileService) {

    this.profileService.MyProfile().subscribe(data => {
      this.user = data;
    })

    console.log(this.user);
  }

  ngOnInit() {
  }

  a() {
    console.log(this.user);
  }
}
