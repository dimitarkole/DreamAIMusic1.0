import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/core/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})

export class SignupComponent implements OnInit {
  signUpForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit() {
    this.signUpForm = this.fb.group({
      email: [null, [Validators.required, Validators.email]],
      username: [null, [Validators.required]],
      password: [null, [ Validators.required, Validators.minLength(6)]],
    });
  }

  signUp() {
    const { email, password, username } = this.signUpForm.value;
      this.authService.register(email, password, username)
      .subscribe(_ => {
        this.router.navigate([ '/login' ]);
      });
  }
}
