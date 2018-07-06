import { Component } from '@angular/core';

@Component({
  selector: 'ngx-footer',
  styleUrls: ['./footer.component.scss'],
  template: `
    <span class="created-by">Lavet med ♥ af <b><a href="https://akveo.com" target="_blank"
    >StofBangeBois</a></b> 2017</span>
    <div class="socials">
      <a href="#" target="_blank" class="ion ion-social-facebook"></a>
    </div>
  `,
})
export class FooterComponent {
}
