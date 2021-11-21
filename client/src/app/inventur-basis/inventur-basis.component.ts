import { Component, Injector } from '@angular/core';
import { InventurBasisGenerated } from './inventur-basis-generated.component';

@Component({
  selector: 'page-inventur-basis',
  templateUrl: './inventur-basis.component.html'
})
export class InventurBasisComponent extends InventurBasisGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
