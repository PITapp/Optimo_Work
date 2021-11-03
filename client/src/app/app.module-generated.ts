/*
  This file is automatically generated. Any changes will be overwritten.
  Modify app.module.ts instead.
*/
import { APP_INITIALIZER } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BodyModule } from '@radzen/angular/dist/body';
import { CardModule } from '@radzen/angular/dist/card';
import { ImageModule } from '@radzen/angular/dist/image';
import { LabelModule } from '@radzen/angular/dist/label';
import { ContentContainerModule } from '@radzen/angular/dist/content-container';
import { HeaderModule } from '@radzen/angular/dist/header';
import { SidebarToggleModule } from '@radzen/angular/dist/sidebar-toggle';
import { LinkModule } from '@radzen/angular/dist/link';
import { ProfileMenuModule } from '@radzen/angular/dist/profilemenu';
import { SidebarModule } from '@radzen/angular/dist/sidebar';
import { PanelMenuModule } from '@radzen/angular/dist/panelmenu';
import { FooterModule } from '@radzen/angular/dist/footer';
import { ContentModule } from '@radzen/angular/dist/content';
import { TemplateFormModule } from '@radzen/angular/dist/template-form';
import { RequiredValidatorModule } from '@radzen/angular/dist/required-validator';
import { DropDownModule } from '@radzen/angular/dist/dropdown';
import { TextBoxModule } from '@radzen/angular/dist/textbox';
import { ListBoxModule } from '@radzen/angular/dist/listbox';
import { PasswordModule } from '@radzen/angular/dist/password';
import { TextAreaModule } from '@radzen/angular/dist/textarea';
import { ButtonModule } from '@radzen/angular/dist/button';
import { HeadingModule } from '@radzen/angular/dist/heading';
import { TabsModule } from '@radzen/angular/dist/tabs';
import { PanelModule } from '@radzen/angular/dist/panel';
import { GridModule } from '@radzen/angular/dist/grid';
import { ProgressBarModule } from '@radzen/angular/dist/progressbar';
import { GaugeModule } from '@radzen/angular/dist/gauge';
import { SparklineModule } from '@radzen/angular/dist/sparkline';
import { SelectBarModule } from '@radzen/angular/dist/selectbar';
import { ChartModule } from '@radzen/angular/dist/chart';
import { SchedulerModule } from '@radzen/angular/dist/scheduler';
import { DataListModule } from '@radzen/angular/dist/datalist';
import { HtmlModule } from '@radzen/angular/dist/html';
import { UploadModule } from '@radzen/angular/dist/upload';
import { DatePickerModule } from '@radzen/angular/dist/datepicker';
import { LoginModule } from '@radzen/angular/dist/login';
import { SharedModule } from '@radzen/angular/dist/shared';
import { NotificationModule } from '@radzen/angular/dist/notification';
import { DialogModule } from '@radzen/angular/dist/dialog';

import { ConfigService, configServiceFactory } from './config.service';
import { AppRoutes } from './app.routes';
import { AppComponent } from './app.component';
import { CacheInterceptor } from './cache.interceptor';
export { AppComponent } from './app.component';
import { BenutzerNeuComponent } from './benutzer-neu/benutzer-neu.component';
import { BenutzerComponent } from './benutzer/benutzer.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EinstellungenComponent } from './einstellungen/einstellungen.component';
import { BenutzerProfilComponent } from './benutzer-profil/benutzer-profil.component';
import { KontaktComponent } from './kontakt/kontakt.component';
import { KontakteComponent } from './kontakte/kontakte.component';
import { KontakteNeuComponent } from './kontakte-neu/kontakte-neu.component';
import { KontakteBearbeitenComponent } from './kontakte-bearbeiten/kontakte-bearbeiten.component';
import { EinstellungenInfotexteNeuComponent } from './einstellungen-infotexte-neu/einstellungen-infotexte-neu.component';
import { EinstellungenInfotexteBearbeitenComponent } from './einstellungen-infotexte-bearbeiten/einstellungen-infotexte-bearbeiten.component';
import { MeldungLoeschenComponent } from './meldung-loeschen/meldung-loeschen.component';
import { MeldungJaNeinComponent } from './meldung-ja-nein/meldung-ja-nein.component';
import { BenutzerBearbeitenComponent } from './benutzer-bearbeiten/benutzer-bearbeiten.component';
import { VersionenComponent } from './versionen/versionen.component';
import { HandbuchComponent } from './handbuch/handbuch.component';
import { LoginComponent } from './login/login.component';
import { EinstellungenInfotexteEditorComponent } from './einstellungen-infotexte-editor/einstellungen-infotexte-editor.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { KontakteKontaktpersonenNeuComponent } from './kontakte-kontaktpersonen-neu/kontakte-kontaktpersonen-neu.component';
import { KontakteKontaktpersonenBearbeitenComponent } from './kontakte-kontaktpersonen-bearbeiten/kontakte-kontaktpersonen-bearbeiten.component';
import { KontakteSuchenComponent } from './kontakte-suchen/kontakte-suchen.component';
import { InventurComponent } from './inventur/inventur.component';
import { ZzMusterKontakteComponent } from './zz-muster-kontakte/zz-muster-kontakte.component';
import { MeldungOkComponent } from './meldung-ok/meldung-ok.component';
import { MeldungFortschrittComponent } from './meldung-fortschritt/meldung-fortschritt.component';
import { NotizenEditorComponent } from './notizen-editor/notizen-editor.component';
import { LoginLayoutComponent } from './login-layout/login-layout.component';
import { MainLayoutComponent } from './main-layout/main-layout.component';

import { DbOptimoService } from './db-optimo.service';
import { SecurityService, UserService } from './security.service';
import { SecurityInterceptor } from './security.interceptor';
import { AuthGuard } from './auth.guard';

export const PageDeclarations = [
  BenutzerNeuComponent,
  BenutzerComponent,
  DashboardComponent,
  EinstellungenComponent,
  BenutzerProfilComponent,
  KontaktComponent,
  KontakteComponent,
  KontakteNeuComponent,
  KontakteBearbeitenComponent,
  EinstellungenInfotexteNeuComponent,
  EinstellungenInfotexteBearbeitenComponent,
  MeldungLoeschenComponent,
  MeldungJaNeinComponent,
  BenutzerBearbeitenComponent,
  VersionenComponent,
  HandbuchComponent,
  LoginComponent,
  EinstellungenInfotexteEditorComponent,
  UnauthorizedComponent,
  KontakteKontaktpersonenNeuComponent,
  KontakteKontaktpersonenBearbeitenComponent,
  KontakteSuchenComponent,
  InventurComponent,
  ZzMusterKontakteComponent,
  MeldungOkComponent,
  MeldungFortschrittComponent,
  NotizenEditorComponent,
];

export const LayoutDeclarations = [
  LoginLayoutComponent,
  MainLayoutComponent,
];

export const AppDeclarations = [
  ...PageDeclarations,
  ...LayoutDeclarations,
  AppComponent
];

export const AppProviders = [
  {
    provide: HTTP_INTERCEPTORS,
    useClass: CacheInterceptor,
    multi: true
  },
  DbOptimoService,
  UserService,
  SecurityService,
  {
    provide: HTTP_INTERCEPTORS,
    useClass: SecurityInterceptor,
    multi: true
  },
  AuthGuard,
  ConfigService,
  {
    provide: APP_INITIALIZER,
    useFactory: configServiceFactory,
    deps: [ConfigService],
    multi: true
  }
];

export const AppImports = [
  BrowserModule,
  BrowserAnimationsModule,
  FormsModule,
  HttpClientModule,
  BodyModule,
  CardModule,
  ImageModule,
  LabelModule,
  ContentContainerModule,
  HeaderModule,
  SidebarToggleModule,
  LinkModule,
  ProfileMenuModule,
  SidebarModule,
  PanelMenuModule,
  FooterModule,
  ContentModule,
  TemplateFormModule,
  RequiredValidatorModule,
  DropDownModule,
  TextBoxModule,
  ListBoxModule,
  PasswordModule,
  TextAreaModule,
  ButtonModule,
  HeadingModule,
  TabsModule,
  PanelModule,
  GridModule,
  ProgressBarModule,
  GaugeModule,
  SparklineModule,
  SelectBarModule,
  ChartModule,
  SchedulerModule,
  DataListModule,
  HtmlModule,
  UploadModule,
  DatePickerModule,
  LoginModule,
  SharedModule,
  NotificationModule,
  DialogModule,
  AppRoutes
];
