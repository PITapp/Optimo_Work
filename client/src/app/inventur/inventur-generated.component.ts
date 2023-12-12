/*
  This file is automatically generated. Any changes will be overwritten.
  Modify inventur.component.ts instead.
*/
import { LOCALE_ID, ChangeDetectorRef, ViewChild, AfterViewInit, Injector, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Subscription } from 'rxjs';

import { DialogService, DIALOG_PARAMETERS, DialogRef } from '@radzen/angular/dist/dialog';
import { NotificationService } from '@radzen/angular/dist/notification';
import { ContentComponent } from '@radzen/angular/dist/content';
import { HeadingComponent } from '@radzen/angular/dist/heading';
import { ButtonComponent } from '@radzen/angular/dist/button';
import { TabsComponent } from '@radzen/angular/dist/tabs';
import { PanelComponent } from '@radzen/angular/dist/panel';
import { GridComponent } from '@radzen/angular/dist/grid';
import { LabelComponent } from '@radzen/angular/dist/label';
import { ImageComponent } from '@radzen/angular/dist/image';

import { ConfigService } from '../config.service';
import { MeldungOkComponent } from '../meldung-ok/meldung-ok.component';
import { InventurLagerorteBearbeitenComponent } from '../inventur-lagerorte-bearbeiten/inventur-lagerorte-bearbeiten.component';

import { DbOptimoService } from '../db-optimo.service';
import { SecurityService } from '../security.service';

export class InventurGenerated implements AfterViewInit, OnInit, OnDestroy {
  // Components
  @ViewChild('content1') content1: ContentComponent;
  @ViewChild('heading18') heading18: HeadingComponent;
  @ViewChild('heading19') heading19: HeadingComponent;
  @ViewChild('heading21') heading21: HeadingComponent;
  @ViewChild('button1') button1: ButtonComponent;
  @ViewChild('tabs0') tabs0: TabsComponent;
  @ViewChild('panel1') panel1: PanelComponent;
  @ViewChild('gridLagerorte') gridLagerorte: GridComponent;
  @ViewChild('buttonLagerortBearbeiten') buttonLagerortBearbeiten: ButtonComponent;
  @ViewChild('buttonLagerorteAktualisieren') buttonLagerorteAktualisieren: ButtonComponent;
  @ViewChild('panel0') panel0: PanelComponent;
  @ViewChild('gridErfassungLagerorte') gridErfassungLagerorte: GridComponent;
  @ViewChild('buttonBearbeitenProtokoll') buttonBearbeitenProtokoll: ButtonComponent;
  @ViewChild('panel2') panel2: PanelComponent;
  @ViewChild('gridArtikel') gridArtikel: GridComponent;
  @ViewChild('buttonArtikelExport') buttonArtikelExport: ButtonComponent;
  @ViewChild('button0') button0: ButtonComponent;
  @ViewChild('panel3') panel3: PanelComponent;
  @ViewChild('gridErfassungArtikel') gridErfassungArtikel: GridComponent;
  @ViewChild('buttonExportArtikelErfassung') buttonExportArtikelErfassung: ButtonComponent;
  @ViewChild('panel4') panel4: PanelComponent;
  @ViewChild('gridErfassung') gridErfassung: GridComponent;
  @ViewChild('buttonErfassungExport') buttonErfassungExport: ButtonComponent;
  @ViewChild('button2') button2: ButtonComponent;
  @ViewChild('panel5') panel5: PanelComponent;
  @ViewChild('gridErfassungSummen') gridErfassungSummen: GridComponent;
  @ViewChild('buttonErfassungSummenExport') buttonErfassungSummenExport: ButtonComponent;
  @ViewChild('button3') button3: ButtonComponent;
  @ViewChild('panel6') panel6: PanelComponent;
  @ViewChild('image0') image0: ImageComponent;
  @ViewChild('panel7') panel7: PanelComponent;
  @ViewChild('image1') image1: ImageComponent;

  router: Router;

  cd: ChangeDetectorRef;

  route: ActivatedRoute;

  notificationService: NotificationService;

  configService: ConfigService;

  dialogService: DialogService;

  dialogRef: DialogRef;

  httpClient: HttpClient;

  locale: string;

  _location: Location;

  _subscription: Subscription;

  dbOptimo: DbOptimoService;

  security: SecurityService;
  letzteInventurID: any;
  parameters: any;
  rstLagerorte: any;
  rstLagerorteCount: any;
  dsoLagerort: any;
  rstErfassungLagerorte: any;
  rstErfassungLagerorteCount: any;
  rstArtikel: any;
  rstArtikelCount: any;
  dsoArtikel: any;
  rstErfassungArtikel: any;
  rstErfassungArtikelCount: any;
  rstErfassung: any;
  rstErfassungCount: any;
  dsoErfassung: any;
  rstErfassungSummen: any;
  rstErfassungSummenCount: any;
  dsoErfassungSummen: any;

  constructor(private injector: Injector) {
  }

  ngOnInit() {
    this.notificationService = this.injector.get(NotificationService);

    this.configService = this.injector.get(ConfigService);

    this.dialogService = this.injector.get(DialogService);

    this.dialogRef = this.injector.get(DialogRef, null);

    this.locale = this.injector.get(LOCALE_ID);

    this.router = this.injector.get(Router);

    this.cd = this.injector.get(ChangeDetectorRef);

    this._location = this.injector.get(Location);

    this.route = this.injector.get(ActivatedRoute);

    this.httpClient = this.injector.get(HttpClient);

    this.dbOptimo = this.injector.get(DbOptimoService);
    this.security = this.injector.get(SecurityService);
  }

  ngAfterViewInit() {
    this._subscription = this.route.params.subscribe(parameters => {
      if (this.dialogRef) {
        this.parameters = this.injector.get(DIALOG_PARAMETERS);
      } else {
        this.parameters = parameters;
      }
      this.load();
      this.cd.detectChanges();
    });
  }

  ngOnDestroy() {
    if (this._subscription) {
      this._subscription.unsubscribe();
    }
  }


  load() {
    this.letzteInventurID = null;

    this.gridLagerorte.load();

    this.gridArtikel.load();

    this.gridErfassung.load();

    this.gridErfassungSummen.load();
  }

  button1Click(event: any) {
    this.dialogService.open(MeldungOkComponent, { parameters: {strMeldung: "Drucken ist für dieses Modul noch nicht aktiviert!"}, width: 600, title: `Info` });
  }

  gridLagerorteLoadData(event: any) {
    this.dbOptimo.getVwInventurLagerortes(`${event.filter}`, event.top, event.skip, `${event.orderby || 'ErfassungNr, Lagerort'}`, event.top != null && event.skip != null, null, null, null)
    .subscribe((result: any) => {
      this.rstLagerorte = result.value;

      this.rstLagerorteCount = event.top != null && event.skip != null ? result['@odata.count'] : result.value.length;

      if (this.rstLagerorte.find(p => p.InventurID == this.letzteInventurID) != null) {
    // letzteInventurID wurde in rstLagerorte gefunden
    this.gridLagerorte.onSelect(this.rstLagerorte.find(p => p.InventurID == this.letzteInventurID))
} else {
    // letzteInventurID wurde in rstLagerorte NICHT gefunden
    this.letzteInventurID = null;
    this.gridLagerorte.onSelect(this.rstLagerorte[0]);
}
    }, (result: any) => {
      this.notificationService.notify({ severity: "error", summary: ``, detail: `Lagerorte können nicht geladen werden!` });
    });
  }

  gridLagerorteRowDoubleClick(event: any) {
    this.buttonLagerortBearbeitenClick(null);
  }

  gridLagerorteRowSelect(event: any) {
    this.dsoLagerort = event;

    this.dbOptimo.getVwInventurErfassungs(`InventurID eq ${event.InventurID}`, null, null, `${event.orderby || 'ErfasstAm DESC'}`, null, null, null, null)
    .subscribe((result: any) => {
      this.rstErfassungLagerorte = result.value;

      this.rstErfassungLagerorteCount = event.top != null && event.skip != null ? result['@odata.count'] : result.value.length;
    }, (result: any) => {

    });
  }

  buttonLagerortBearbeitenClick(event: any) {
    this.letzteInventurID = this.dsoLagerort.InventurID;

    this.dialogService.open(InventurLagerorteBearbeitenComponent, { parameters: {InventurID: this.dsoLagerort.InventurID}, title: `Lagerort bearbeiten` })
        .afterClosed().subscribe(result => {
              if (result != null) {
        this.gridLagerorte.load();
      }
    });
  }

  buttonLagerorteAktualisierenClick(event: any) {
    this.gridLagerorte.load();
  }

  buttonBearbeitenProtokollClick(event: any) {
    this.dialogService.open(MeldungOkComponent, { parameters: {strMeldung: "Export ist für dieses Modul noch nicht aktiviert!"}, title: `Info` });
  }

  gridArtikelLoadData(event: any) {
    this.dbOptimo.getVwInventurArtikels(`${event.filter}`, event.top, event.skip, `${event.orderby}`, event.top != null && event.skip != null, null, null, null)
    .subscribe((result: any) => {
      this.rstArtikel = result.value;

      this.rstArtikelCount = event.top != null && event.skip != null ? result['@odata.count'] : result.value.length;

      this.gridArtikel.onSelect(this.rstArtikel[0]);
    }, (result: any) => {
      this.notificationService.notify({ severity: "error", summary: ``, detail: `Artikel können nicht geladen werden!` });
    });
  }

  gridArtikelRowSelect(event: any) {
    this.dsoArtikel = event;

    this.dbOptimo.getVwInventurErfassungs(`ArtikelID eq ${event.ArtikelID}`, null, null, `${event.orderby || 'ErfasstAm DESC'}`, null, null, null, null)
    .subscribe((result: any) => {
      this.rstErfassungArtikel = result.value;

      this.rstErfassungArtikelCount = event.top != null && event.skip != null ? result['@odata.count'] : result.value.length;
    }, (result: any) => {

    });
  }

  buttonArtikelExportClick(event: any) {
    this.dialogService.open(MeldungOkComponent, { parameters: {strMeldung: "Export ist für dieses Modul noch nicht aktiviert!"}, title: `Info` });
  }

  button0Click(event: any) {
    this.gridArtikel.load();
  }

  buttonExportArtikelErfassungClick(event: any) {
    this.dialogService.open(MeldungOkComponent, { parameters: {strMeldung: "Export ist für dieses Modul noch nicht aktiviert!"}, title: `Info` });
  }

  gridErfassungLoadData(event: any) {
    this.dbOptimo.getVwInventurErfassungs(`${event.filter}`, event.top, event.skip, `${event.orderby || 'ErfasstAm DESC'}`, event.top != null && event.skip != null, null, null, null)
    .subscribe((result: any) => {
      this.rstErfassung = result.value;

      this.rstErfassungCount = event.top != null && event.skip != null ? result['@odata.count'] : result.value.length;

      this.gridErfassung.onSelect(this.rstErfassung[0]);
    }, (result: any) => {
      this.notificationService.notify({ severity: "error", summary: ``, detail: `Erfassung konnte nicht geladen werden!` });
    });
  }

  gridErfassungRowSelect(event: any) {
    this.dsoErfassung = event;
  }

  buttonErfassungExportClick(event: any) {
    this.dialogService.open(MeldungOkComponent, { parameters: {strMeldung: "Export ist für dieses Modul noch nicht aktiviert!"}, title: `Info` });
  }

  button2Click(event: any) {
    this.gridErfassung.load();
  }

  gridErfassungSummenLoadData(event: any) {
    this.dbOptimo.getVwErfassungSummens(`${event.filter}`, event.top, event.skip, `${event.orderby}`, event.top != null && event.skip != null, null, null, null)
    .subscribe((result: any) => {
      this.rstErfassungSummen = result.value;

      this.rstErfassungSummenCount = event.top != null && event.skip != null ? result['@odata.count'] : result.value.length;

      this.gridErfassungSummen.onSelect(this.rstErfassungSummen[0]);
    }, (result: any) => {
      this.notificationService.notify({ severity: "error", summary: ``, detail: `Erfassung Summen konnte nicht geladen werden!` });
    });
  }

  gridErfassungSummenRowSelect(event: any) {
    this.dsoErfassungSummen = event;
  }

  buttonErfassungSummenExportClick(event: any) {
    this.dialogService.open(MeldungOkComponent, { parameters: {strMeldung: "Export ist für dieses Modul noch nicht aktiviert!"}, title: `Info` });
  }

  button3Click(event: any) {
    this.gridErfassungSummen.load();
  }
}
