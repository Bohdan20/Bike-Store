import { Component, ViewEncapsulation } from '@angular/core';
import { Router, NavigationEnd, NavigationStart } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/filter';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css', 'styles/bike.css'],
  encapsulation: ViewEncapsulation.None
})
export class AppComponent {
  showNavbar = false;
  title = 'app';

  constructor(private router: Router, private authService: AuthService) {
    this.router.events.filter(e => e instanceof NavigationStart).subscribe(() => {
      this.showNavbar = this.authService.isLoggedIn();
    });
    this.router.events.filter(e => e instanceof NavigationEnd).subscribe(() => {
      this.showNavbar = this.authService.isLoggedIn();
    });
  }

  savedConfigurations() {
    this.router.navigate(['/saved-configurations']);
  }

  goToAdmin() {
    this.router.navigate(['/admin']);
  }

  logout() {
    this.authService.logout();
    this.showNavbar = false;
    this.router.navigate(['/signin']);
  }
}
