import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/core/services/auth.service';
import { Router, Data } from '@angular/router';
import { ConfirmedValidator } from '../../common/confirmed.validator';
import User from '../../components/shared/models/user';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})

export class SignupComponent implements OnInit {
  signUpForm: FormGroup;
  maxDate: number;
  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit() {
    this.signUpForm = this.fb.group({
      email: [null, [Validators.required, Validators.email]],
      name: [null, [Validators.required, Validators.minLength(1), Validators.maxLength(30)]],
      family: [null, [Validators.required, Validators.minLength(1), Validators.maxLength(30)]],
      username: [null, [Validators.required, Validators.minLength(5), Validators.maxLength(30)]],
      password: [null, [Validators.required, Validators.minLength(8), Validators.maxLength(20)]],
      confirmPassword: [null, [Validators.required]],
      birthday: [null, [Validators.required]],
    }, {
        validator: ConfirmedValidator('password', 'confirmPassword')
    });
    this.maxDate = Date.now();
  }

  signUp() {
    if (this.signUpForm.invalid) {
      return;
    }

    let newUser: User = this.signUpForm.value;
    this.authService.register(newUser)
      .subscribe(_ => {
        this.router.navigate([ '/login' ]);
      });
  }

  password() {
    return this.signUpForm.get('password');
  }

  email() {
    return this.signUpForm.get('email');
  }

  username() {
    return this.signUpForm.get('username');
  }

  name() {
    return this.signUpForm.get('name');
  }

  family() {
    return this.signUpForm.get('family');
  }

  confirmPassword() {
    return this.signUpForm.get('confirmPassword');
  }

  birthday() {
    return this.signUpForm.get('birthday'); 
  }

  today() {
    return Date.now();
  }
}
