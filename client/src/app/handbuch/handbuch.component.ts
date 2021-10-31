import { Component, Injector } from '@angular/core';
import { HandbuchGenerated } from './handbuch-generated.component';

@Component({
  selector: 'page-handbuch',
  templateUrl: './handbuch.component.html'
})
export class HandbuchComponent extends HandbuchGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
