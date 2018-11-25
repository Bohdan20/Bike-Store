import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginModel } from '../models/login.model';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { Host } from '../helpers/host.helper';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['../styles/form.css']
})
export class SigninComponent extends Host implements OnInit {
  loginModel: LoginModel;
  loginForm: FormGroup;
  loginError: string;
  isLoginFailed = false;
  backImgSrc: string;
  constructor(private formBuilder: FormBuilder,
              private authService: AuthService,
              private router: Router) {
    super();
    this.backImgSrc = `url(${this.hostForImg}/assets/images/bike_backgound.jpg)`;
  }

  ngOnInit() {
    this.createForm();
  }

  goToSignUpPage() {
    this.router.navigateByUrl('/signup');
  }

  login() {
    this.authService.login(this.getValuesFromForm()).subscribe(
      (data) => {
        this.isLoginFailed = false;
        if (this.authService.isLoggedIn) {
          this.router.navigateByUrl('choose-model');
        }
      },
      (error) => {
        this.isLoginFailed = true;
        this.loginError = JSON.parse(error._body).error_description;
      }
    );
  }

  private createForm() {
    this.loginForm = this.formBuilder.group({
      UserName: [''],
      Password: ['']
    });
    this.loginForm.patchValue({
      UserName: '',
      Password: ''
    });
  }

  private getValuesFromForm(): string {
    const values = this.loginForm.getRawValue();
    this.loginModel = {
      userName: values.UserName,
      password: values.Password
    };

    const queryParams = `grant_type=password&
                         password=${this.loginModel.password}&
                         userName=${this.loginModel.userName}`;

    return queryParams;
  }

}
