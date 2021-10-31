import { Component, Injector } from '@angular/core';
import { NotizenEditorGenerated } from './notizen-editor-generated.component';

@Component({
  selector: 'page-notizen-editor',
  templateUrl: './notizen-editor.component.html'
})
export class NotizenEditorComponent extends NotizenEditorGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
