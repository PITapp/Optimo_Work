import { Component, Injector } from '@angular/core';
import { BenutzerProfilGenerated } from './benutzer-profil-generated.component';

@Component({
  selector: 'page-benutzer-profil',
  templateUrl: './benutzer-profil.component.html'
})
export class BenutzerProfilComponent extends BenutzerProfilGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
