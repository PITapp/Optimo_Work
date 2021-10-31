import { Component, Injector } from '@angular/core';
import { KontakteKontaktpersonenBearbeitenGenerated } from './kontakte-kontaktpersonen-bearbeiten-generated.component';

@Component({
  selector: 'page-kontakte-kontaktpersonen-bearbeiten',
  templateUrl: './kontakte-kontaktpersonen-bearbeiten.component.html'
})
export class KontakteKontaktpersonenBearbeitenComponent extends KontakteKontaktpersonenBearbeitenGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
