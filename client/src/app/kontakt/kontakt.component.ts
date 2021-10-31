import { Component, Injector } from '@angular/core';
import { KontaktGenerated } from './kontakt-generated.component';

@Component({
  selector: 'page-kontakt',
  templateUrl: './kontakt.component.html'
})
export class KontaktComponent extends KontaktGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
