import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms/src/model';
import { FormBuilder } from '@angular/forms';

import { RegisterModel } from '../models/register.model';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { Host } from '../helpers/host.helper';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['../styles/form.css']
})
export class SignupComponent extends Host implements OnInit {
  registerModel: RegisterModel;
  registerForm: FormGroup;
  registrationSuccessful = false;
  registrationFailed = false;
  errorMessages: string[];
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

  registerUser() {
    this.setValuesToModel();

    this.authService.register(this.registerModel).subscribe(
      (data) => {
        this.registrationSuccessful = true;
      },
      (error) => {
        this.registrationFailed = true;
        const errorResult = JSON.parse(error._body).ModelState;
        this.errorMessages = this.getErrorMessages(errorResult);
      }
    );
  }

  goToLogin() {
    this.router.navigate(['/signin']);
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
    this.registerForm = this.formBuilder.group({
      Email: [''],
      UserName: [''],
      FirstName: [''],
      LastName: [''],
      Password: [''],
      ConfirmPassword: ['']
    });

    this.registerForm.patchValue({
      Email: '',
      UserName: '',
      FirstName: '',
      LastName: '',
      Password: '',
      ConfirmPassword: ''
    });
  }

  private setValuesToModel() {
    const values = this.registerForm.getRawValue();

    this.registerModel = {
      email: values.Email,
      userName: values.UserName,
      firstName: values.FirstName,
      lastName: values.LastName,
      password: values.Password,
      confirmPassword: values.ConfirmPassword
    };
  }

}
