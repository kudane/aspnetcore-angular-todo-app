import { Component, OnInit } from '@angular/core';
import { User, UserService } from '../../../core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  isAuthenticated = false;
  logonName: string;

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.isAuthenticated.subscribe(
      (authenticated) => this.isAuthenticated = authenticated
    );

    this.userService.currentUser.subscribe(
      (user: User) => {
        if (user) {
          this.logonName = `${user.firstname} ${user.lastname}`
        } else {
          this.logonName = '';
        }
      }
    );
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  onSignout() {
    this.userService.purgeAuth();
    this.logonName = '';
  }
}
