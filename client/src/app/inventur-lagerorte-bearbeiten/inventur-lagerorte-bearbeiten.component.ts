import { Component, Injector } from '@angular/core';
import { InventurLagerorteBearbeitenGenerated } from './inventur-lagerorte-bearbeiten-generated.component';

@Component({
  selector: 'page-inventur-lagerorte-bearbeiten',
  templateUrl: './inventur-lagerorte-bearbeiten.component.html'
})
export class InventurLagerorteBearbeitenComponent extends InventurLagerorteBearbeitenGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
