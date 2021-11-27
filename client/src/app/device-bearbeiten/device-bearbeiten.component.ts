import { Component, Injector } from '@angular/core';
import { DeviceBearbeitenGenerated } from './device-bearbeiten-generated.component';

@Component({
  selector: 'page-device-bearbeiten',
  templateUrl: './device-bearbeiten.component.html'
})
export class DeviceBearbeitenComponent extends DeviceBearbeitenGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
