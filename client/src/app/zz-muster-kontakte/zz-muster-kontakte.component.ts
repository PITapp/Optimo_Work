import { Component, Injector } from '@angular/core';
import { ZzMusterKontakteGenerated } from './zz-muster-kontakte-generated.component';

@Component({
  selector: 'page-zz-muster-kontakte',
  templateUrl: './zz-muster-kontakte.component.html'
})
export class ZzMusterKontakteComponent extends ZzMusterKontakteGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
