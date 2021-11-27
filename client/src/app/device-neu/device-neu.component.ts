import { Component, Injector } from '@angular/core';
import { DeviceNeuGenerated } from './device-neu-generated.component';

@Component({
  selector: 'page-device-neu',
  templateUrl: './device-neu.component.html'
})
export class DeviceNeuComponent extends DeviceNeuGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
