import { Component, Injector } from '@angular/core';
import { InventurGenerated } from './inventur-generated.component';

@Component({
  selector: 'page-inventur',
  templateUrl: './inventur.component.html'
})
export class InventurComponent extends InventurGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
