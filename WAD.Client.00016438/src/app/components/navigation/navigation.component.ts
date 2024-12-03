//Student Id: 00016438

import { Location } from '@angular/common';
import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navigation',
  standalone: true,
  imports: [],
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.css',
})
export class NavigationComponent {
  location = inject(Location);
  router = inject(Router);

  goBack() {
    this.location.back();
  }

  goHome() {
    this.router.navigate(['/students']);
  }
}
