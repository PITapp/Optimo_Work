import { Component, Injector } from '@angular/core';
import { KontakteKontaktpersonenNeuGenerated } from './kontakte-kontaktpersonen-neu-generated.component';

@Component({
  selector: 'page-kontakte-kontaktpersonen-neu',
  templateUrl: './kontakte-kontaktpersonen-neu.component.html'
})
export class KontakteKontaktpersonenNeuComponent extends KontakteKontaktpersonenNeuGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
