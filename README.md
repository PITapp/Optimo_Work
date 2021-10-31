# Hauptfarbe 
orange: #F1903C
orange dunkler: #D86E13

alternativ Schaltfläche: background-color: #fa7d19;

# Farbe Icon Hintergrund orange: DE8823

# Whitesmoke: f5f5f5

# Quill Editor einbinden
https://www.primefaces.org/primeng/showcase/#/editor

- npm install quill --save

import * as Quill from 'quill/dist/quill';
(<any>window).Quill = Quill;
import { EditorModule } from 'primeng/editor';



# push an existing repository from the command line
git remote add origin https://github.com/PITapp/SinDarEla_WebApp.git
git branch -M main
git push -u origin main

# Berichte erzeugen:
https://forum.radzen.com/t/creating-reports/5844
https://github.com/FastReports/FastReport
https://www.stimulsoft.com/de

# Löschen node_modules und neu installieren
> cd cliend 
> rm -r node_modules
> npm install

# Interesante Links
> Theme: https://www.primefaces.org/verona-ng/#/
> Theme: https://www.primefaces.org/olympia/

# TinyMCE Editor einbinden
https://www.tiny.cloud/docs/integrations/angular/#tinymceangulartechnicalreference
https://github.com/tinymce/tinymce-angular

> For Angular 8 and below use integration version 3.x:
npm install --save @tinymce/tinymce-angular@^3.0.0

import { BrowserModule } from '@angular/platform-browser';
 import { NgModule } from '@angular/core';
 import { EditorModule } from '@tinymce/tinymce-angular';
 import { AppComponent } from './app.component';

 @NgModule({
   declarations: [
     AppComponent
   ],
   imports: [
     BrowserModule,
     EditorModule
   ],
   providers: [],
   bootstrap: [AppComponent]
 })
 export class AppModule { }
