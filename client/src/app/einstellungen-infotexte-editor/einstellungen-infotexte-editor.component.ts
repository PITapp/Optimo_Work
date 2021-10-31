import { Component, Injector } from '@angular/core';
import { EinstellungenInfotexteEditorGenerated } from './einstellungen-infotexte-editor-generated.component';

@Component({
  selector: 'page-einstellungen-infotexte-editor',
  templateUrl: './einstellungen-infotexte-editor.component.html'
})
export class EinstellungenInfotexteEditorComponent extends EinstellungenInfotexteEditorGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
