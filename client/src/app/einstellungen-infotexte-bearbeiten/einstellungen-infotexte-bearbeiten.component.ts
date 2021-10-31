import { Component, Injector } from '@angular/core';
import { EinstellungenInfotexteBearbeitenGenerated } from './einstellungen-infotexte-bearbeiten-generated.component';

@Component({
  selector: 'page-einstellungen-infotexte-bearbeiten',
  templateUrl: './einstellungen-infotexte-bearbeiten.component.html'
})
export class EinstellungenInfotexteBearbeitenComponent extends EinstellungenInfotexteBearbeitenGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
