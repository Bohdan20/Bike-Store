import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { Host } from '../helpers/host.helper';

@Component({
  selector: 'app-choose-model',
  templateUrl: './choose-model.component.html',
  styleUrls: ['./choose-model.component.css', '../styles/bike.css']
})
export class ChooseModelComponent extends Host implements OnInit {
  isClosedSC2 = true;
  isClosedSC3 = true;

  constructor(private authService: AuthService, private router: Router) {
    super();
  }

  ngOnInit() {
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/']);
  }

  savedConfigurations() {
    this.router.navigate(['/saved-configurations']);
  }
  selectSC2() {
    this.router.navigate(['/sc2-model']);
  }

  selectSC3() {
    this.router.navigate(['/sc3-model']);
  }

}
