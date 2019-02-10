import { Component, Input } from '@angular/core';
import { navItems } from '../../_nav';
import { Ng4LoadingSpinnerModule, Ng4LoadingSpinnerService  } from 'ng4-loading-spinner';

@Component({
  selector: 'app-dashboard',
  templateUrl: './default-layout.component.html'
})
export class DefaultLayoutComponent {
  public navItems = navItems;
  public sidebarMinimized = true;
  private changes: MutationObserver;
  public element: HTMLElement = document.body;
  constructor(private spinnerService: Ng4LoadingSpinnerService) {
    this.spinnerService.show();
    this.changes = new MutationObserver((mutations) => {
      this.sidebarMinimized = document.body.classList.contains('sidebar-minimized');
    });

    this.changes.observe(<Element>this.element, {
      attributes: true
    });
    this.spinnerService.hide();
  }
}
