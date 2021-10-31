import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule, ActivatedRoute } from '@angular/router';

import { LoginLayoutComponent } from './login-layout/login-layout.component';
import { MainLayoutComponent } from './main-layout/main-layout.component';
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
import { MitarbeiterComponent } from './mitarbeiter/mitarbeiter.component';
import { ZzMusterKontakteComponent } from './zz-muster-kontakte/zz-muster-kontakte.component';
import { MeldungOkComponent } from './meldung-ok/meldung-ok.component';
import { MeldungFortschrittComponent } from './meldung-fortschritt/meldung-fortschritt.component';
import { NotizenEditorComponent } from './notizen-editor/notizen-editor.component';

import { SecurityService } from './security.service';
import { AuthGuard } from './auth.guard';
export const routes: Routes = [
  { path: '', redirectTo: '/kontakte', pathMatch: 'full' },
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      {
        path: 'benutzer-neu',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: BenutzerNeuComponent
      },
      {
        path: 'benutzer',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: BenutzerComponent
      },
      {
        path: 'dashboard',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: DashboardComponent
      },
      {
        path: 'einstellungen',
        canActivate: [AuthGuard],
        data: {
          roles: ['Administrator'],
        },
        component: EinstellungenComponent
      },
      {
        path: 'benutzer-profil',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: BenutzerProfilComponent
      },
      {
        path: 'kontakt',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: KontaktComponent
      },
      {
        path: 'kontakte',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: KontakteComponent
      },
      {
        path: 'kontakte-neu',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: KontakteNeuComponent
      },
      {
        path: 'kontakte-bearbeiten/:BaseID',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: KontakteBearbeitenComponent
      },
      {
        path: 'einstellungen-infotexte-neu',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: EinstellungenInfotexteNeuComponent
      },
      {
        path: 'einstellungen-infotexte-bearbeiten/:NotizID',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: EinstellungenInfotexteBearbeitenComponent
      },
      {
        path: 'meldung-loeschen/:strMeldung',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: MeldungLoeschenComponent
      },
      {
        path: 'meldung-ja-nein/:strMeldung',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: MeldungJaNeinComponent
      },
      {
        path: 'benutzer-bearbeiten/:BenutzerID',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: BenutzerBearbeitenComponent
      },
      {
        path: 'versionen',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: VersionenComponent
      },
      {
        path: 'handbuch',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: HandbuchComponent
      },
      {
        path: 'einstellungen-infotexte-editor/:InfotextID',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: EinstellungenInfotexteEditorComponent
      },
      {
        path: 'unauthorized',
        data: {
          roles: ['Everybody'],
        },
        component: UnauthorizedComponent
      },
      {
        path: 'kontakte-kontaktpersonen-neu/:BaseID',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: KontakteKontaktpersonenNeuComponent
      },
      {
        path: 'kontakte-kontaktpersonen-bearbeiten/:KontaktID',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: KontakteKontaktpersonenBearbeitenComponent
      },
      {
        path: 'kontakte-suchen',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: KontakteSuchenComponent
      },
      {
        path: 'inventur',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: InventurComponent
      },
      {
        path: 'mitarbeiter',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: MitarbeiterComponent
      },
      {
        path: 'zz-muster-kontakte',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: ZzMusterKontakteComponent
      },
      {
        path: 'meldung-ok/:strMeldung',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: MeldungOkComponent
      },
      {
        path: 'meldung-fortschritt',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: MeldungFortschrittComponent
      },
      {
        path: 'notizen-editor/:NotizID',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: NotizenEditorComponent
      },
    ]
  },
  {
    path: '',
    component: LoginLayoutComponent,
    children: [
      {
        path: 'login',
        data: {
          roles: ['Everybody'],
        },
        component: LoginComponent
      },
    ]
  },
];

export const AppRoutes: ModuleWithProviders = RouterModule.forRoot(routes);
