import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ResetPasswordModel } from '../models/reset-password.model';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['../styles/form.css']
})
export class ResetPasswordComponent implements OnInit {
  resetPasswordModel: ResetPasswordModel;
  resetPasswordForm: FormGroup;
  code: string;
  isResetSuccess = false;
  isResetFailed = false;
  errorMessages: string[];

  constructor(private authService: AuthService,
              private activatedRouter: ActivatedRoute,
              private router: Router,
              private formBuilder: FormBuilder) {
    this.code = this.activatedRouter.snapshot.queryParams['code'];
  }

  ngOnInit() {
    this.createForm();
  }

  resetPassword() {
    this.setValuesToModel();

    this.authService.resetPassword(this.resetPasswordModel).subscribe(
      (data) => {
        if (data.statusText === 'OK') {
          this.isResetSuccess = true;
        }
      },
      (error) => {
        this.isResetFailed = true;
        const errorResult = JSON.parse(error._body).ModelState;
        this.errorMessages = this.getErrorMessages(errorResult);
      }
    );
  }

  goToLoginPage() {
    this.router.navigateByUrl('/signin');
  }

  private getErrorMessages(messages: object): string[] {
    const errorMessages: string[] = [];
    for (const key of Object.keys(messages)) {
      if (messages[key].length > 1) {
        for (let i = 0; i < messages[key].length; i++) {
            errorMessages.push(messages[key][i]);
        }
      } else {
        const errorMessage = messages[key][0];
        errorMessages.push(errorMessage);
      }
    }
    return errorMessages;
  }

  private createForm() {
    this.resetPasswordForm = this.formBuilder.group({
      Email: [''],
      Password: [''],
      ConfirmPassword: ['']
    });
    this.resetPasswordForm.patchValue({
      Email: '',
      Password: '',
      ConfirmPassword: ''
    });
  }

  private setValuesToModel() {
    const values = this.resetPasswordForm.getRawValue();

    this.resetPasswordModel = {
      code: this.code,
      email: values.Email,
      password: values.Password,
      confirmPassword: values.ConfirmPassword
    };
  }

}
