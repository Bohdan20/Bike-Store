import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-complete-confirmation',
  templateUrl: './complete-confirmation.component.html',
  styleUrls: ['../styles/form.css']
})
export class CompleteConfirmationComponent implements OnInit {
  userId: string;
  code: string;
  isEmailConfirmed = false;

  constructor(private authService: AuthService,
              private activatedRouter: ActivatedRoute,
              private router: Router) {
    this.userId = this.activatedRouter.snapshot.queryParams['userId'];
    this.code = this.activatedRouter.snapshot.queryParams['code'];
  }

  ngOnInit() {
    this.confirmEmail();
  }

  confirmEmail() {
    this.authService.confirmEmail(this.userId, this.code).subscribe((data) => {
      if (data.statusText === 'OK') {
        this.isEmailConfirmed = true;
      }
    });
  }

  goToLoginPage() {
    this.router.navigateByUrl('/signin');
  }

}
