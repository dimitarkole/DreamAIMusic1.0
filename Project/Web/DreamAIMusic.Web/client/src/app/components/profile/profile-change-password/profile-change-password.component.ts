import { Component, OnInit } from '@angular/core';
import User from '../../shared/models/user';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Router, ActivatedRoute } from '@angular/router';
import { ProfileService } from '../../../core/services/profile.service';

@Component({
  selector: 'app-profile-change-password',
  templateUrl: './profile-change-password.component.html',
  styleUrls: ['./profile-change-password.component.css']
})
export class ProfileChangePasswordComponent implements OnInit {

  userId: string;
  user: User;
  changePasswordForm: FormGroup
  passwordMinLength = 8;
  passwordMaxLength = 30;

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
    this.changePasswordForm = this.formBuilder.group({
      id: this.user.id,
      currentPassword: [
        null,
        [Validators.required, Validators.minLength(1), Validators.maxLength(30)],
      ],
      newPassword: [
        null,
        [Validators.required, Validators.minLength(this.passwordMinLength), Validators.maxLength(this.passwordMaxLength)]
      ],
      confirmNewPassword: [
        null,
        [Validators.required, Validators.minLength(this.passwordMinLength), Validators.maxLength(this.passwordMaxLength)]
      ],
    });
  }
  
  OnSubmit() {
    let user: User = this.changePasswordForm.value;

    this.profileService.changePassword(user)
      .subscribe(_ => {
        this.modal.close(); //It closes successfully
      })
  }

  get id(): AbstractControl {
    return this.changePasswordForm.get('id');
  }

  get currentPassword(): AbstractControl {
    return this.changePasswordForm.get('currentPassword');
  }

  get newPassword(): AbstractControl {
    return this.changePasswordForm.get('newPassword');
  }

  get confirmNewPassword(): AbstractControl {
    return this.changePasswordForm.get('confirmNewPassword');
  }
}
