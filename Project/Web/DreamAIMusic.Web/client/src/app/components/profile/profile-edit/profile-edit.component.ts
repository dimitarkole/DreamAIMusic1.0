import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpEventType } from '@angular/common/http';
import User from '../../shared/models/user';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ProfileService } from '../../../core/services/profile.service';


@Component({
  selector: 'app-profile-edit',
  templateUrl: './profile-edit.component.html',
  styleUrls: ['./profile-edit.component.css']
})
export class ProfileEditComponent implements OnInit {
  userId: string;
  user: User;
  userEditForm: FormGroup
  firstNameMinLength = 1;
  firstNameMaxLength = 30;
  lastNameMinLength = 1;
  lastNameMaxLength = 30;

  constructor(
    public modal: NgbActiveModal,
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
    this.userId = this.user.id;
    this.userEditForm = this.formBuilder.group({
      id: this.user.id,
      firstName: [
        this.user.firstName,
        [Validators.required, Validators.minLength(this.firstNameMinLength), Validators.maxLength(this.firstNameMinLength)],
      ],
      lastName: [
        this.user.lastName,
        [Validators.required, Validators.minLength(this.lastNameMinLength), Validators.maxLength(this.lastNameMaxLength)]
      ],
      birthday: [
        this.user.birthday,
        [Validators.required]
      ],
    });
  }

  OnSubmit() {
    let user: User = this.userEditForm.value;

    console.log(user);
    this.profileService.edit(user)
      .subscribe(_ => {
        this.modal.close(); //It closes successfully
      })
  }

  get id(): AbstractControl {
    return this.userEditForm.get('id');
  }

  get lastName(): AbstractControl {
    return this.userEditForm.get('lastName');
  }

  get firstName(): AbstractControl {
    return this.userEditForm.get('firstName');
  }

  get birthday(): AbstractControl {
    return this.userEditForm.get('birthday');
  }

  get phone(): AbstractControl {
    return this.userEditForm.get('phone');
  }
}
