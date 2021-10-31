import { Component, Injector } from '@angular/core';
import { KontakteBearbeitenGenerated } from './kontakte-bearbeiten-generated.component';

@Component({
  selector: 'page-kontakte-bearbeiten',
  templateUrl: './kontakte-bearbeiten.component.html'
})
export class KontakteBearbeitenComponent extends KontakteBearbeitenGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
