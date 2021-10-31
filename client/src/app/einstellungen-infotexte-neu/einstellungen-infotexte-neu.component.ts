import { Component, Injector } from '@angular/core';
import { EinstellungenInfotexteNeuGenerated } from './einstellungen-infotexte-neu-generated.component';

@Component({
  selector: 'page-einstellungen-infotexte-neu',
  templateUrl: './einstellungen-infotexte-neu.component.html'
})
export class EinstellungenInfotexteNeuComponent extends EinstellungenInfotexteNeuGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
