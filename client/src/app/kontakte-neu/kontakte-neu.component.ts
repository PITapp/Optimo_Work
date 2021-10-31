import { Component, Injector } from '@angular/core';
import { KontakteNeuGenerated } from './kontakte-neu-generated.component';

@Component({
  selector: 'page-kontakte-neu',
  templateUrl: './kontakte-neu.component.html'
})
export class KontakteNeuComponent extends KontakteNeuGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
