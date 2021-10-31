import { NgModule } from '@angular/core';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { AppImports, AppComponent, AppDeclarations, AppProviders } from './app.module-generated';

import { EditorModule } from '@tinymce/tinymce-angular';

@NgModule({
  declarations: [
    ...AppDeclarations
  ],
  imports: [
    environment.production ? ServiceWorkerModule.register('ngsw-worker.js') : [],
    ...AppImports,
    EditorModule
  ],
  providers: [
    ...AppProviders
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
