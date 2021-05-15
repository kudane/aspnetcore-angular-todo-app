import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthSucceeded, Credentials, UserService } from '../core';

@Component({
  selector: 'app-signin-component',
  templateUrl: './signin.component.html'
})
export class SigninComponent {
  signinForm = new FormGroup({
    username: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
  });

  constructor(
    private router: Router,
    private userService: UserService
  ) { }

  onSubmit() {
    if (this.signinForm.invalid) {
      alert("Invalid Username/Password.");
    }

    if (this.signinForm.valid) {
      const credential = this.signinForm.value as Credentials;
      this.userService.attemptAuth(credential).subscribe(
        user => this.router.navigateByUrl('/'),
        err => alert("Authentication Failed.")
      )
    }
  }
}
