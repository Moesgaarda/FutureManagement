import { Component } from '@angular/core';

@Component({
  selector: 'ngx-footer',
  styleUrls: ['./footer.component.scss'],
  template: `
    <span class="created-by"><b><a href="http://techkrus.dk/" target="_blank">Techkrus Digital Solutions</a></b></span>
    <div class="socials">
      <a href="http://facebook.com/techkrus" target="_blank" class="ion ion-social-facebook"></a>
    </div>
  `,
})
export class FooterComponent {
}
