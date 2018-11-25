import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { ForgotPasswordModel } from '../models/forgot-password.model';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Host } from '../helpers/host.helper';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['../styles/form.css']
})
export class ForgotPasswordComponent extends Host implements OnInit {
  forgotPasswordModel: ForgotPasswordModel;
  forgotPasswordForm: FormGroup;
  isEmailSentSuccess = false;
  isEmailSentFailed = false;
  backImgSrc: string;
  constructor(private formBuilder: FormBuilder,
              private authService: AuthService) {
    super();
    this.backImgSrc = `url(${this.hostForImg}/assets/images/bike_backgound.jpg)`;
  }

  ngOnInit() {
    this.createForm();
  }

  forgotPassword() {
    this.forgotPasswordModel = {
      email: this.forgotPasswordForm.getRawValue().Email
    };
    this.authService.forgotPassword(this.forgotPasswordModel).subscribe(
      (data) => {
        if (data.statusText === 'OK') {
          this.isEmailSentSuccess = true;
          this.isEmailSentFailed = !this.isEmailSentSuccess;
        }
      },
      (error) => {
        this.isEmailSentFailed = true;
        this.isEmailSentSuccess = !this.isEmailSentFailed;
      }
    );
  }

  private createForm() {
    this.forgotPasswordForm = this.formBuilder.group({
      Email: ['']
    });
    this.forgotPasswordForm.patchValue({
      Email: ''
    });
  }

}
