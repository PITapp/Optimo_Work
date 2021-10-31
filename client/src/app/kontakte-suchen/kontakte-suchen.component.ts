import { Component, Injector } from '@angular/core';
import { KontakteSuchenGenerated } from './kontakte-suchen-generated.component';

@Component({
  selector: 'page-kontakte-suchen',
  templateUrl: './kontakte-suchen.component.html'
})
export class KontakteSuchenComponent extends KontakteSuchenGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
