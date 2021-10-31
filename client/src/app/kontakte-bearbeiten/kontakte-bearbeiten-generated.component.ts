/*
  This file is automatically generated. Any changes will be overwritten.
  Modify kontakte-bearbeiten.component.ts instead.
*/
import { LOCALE_ID, ChangeDetectorRef, ViewChild, AfterViewInit, Injector, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Subscription } from 'rxjs';

import { DialogService, DIALOG_PARAMETERS, DialogRef } from '@radzen/angular/dist/dialog';
import { NotificationService } from '@radzen/angular/dist/notification';
import { ContentComponent } from '@radzen/angular/dist/content';
import { TemplateFormComponent } from '@radzen/angular/dist/template-form';
import { LabelComponent } from '@radzen/angular/dist/label';
import { DropDownComponent } from '@radzen/angular/dist/dropdown';
import { RequiredValidatorComponent } from '@radzen/angular/dist/required-validator';
import { TextBoxComponent } from '@radzen/angular/dist/textbox';
import { TextAreaComponent } from '@radzen/angular/dist/textarea';
import { DatePickerComponent } from '@radzen/angular/dist/datepicker';
import { ButtonComponent } from '@radzen/angular/dist/button';

import { ConfigService } from '../config.service';

import { DbOptimoService } from '../db-optimo.service';
import { SecurityService } from '../security.service';

export class KontakteBearbeitenGenerated implements AfterViewInit, OnInit, OnDestroy {
  // Components
  @ViewChild('content1') content1: ContentComponent;
  @ViewChild('templateFormKontakte') templateFormKontakte: TemplateFormComponent;
  @ViewChild('label0') label0: LabelComponent;
  @ViewChild('anredeId') anredeId: DropDownComponent;
  @ViewChild('label1') label1: LabelComponent;
  @ViewChild('requiredValidator3') requiredValidator3: RequiredValidatorComponent;
  @ViewChild('name1') name1: TextBoxComponent;
  @ViewChild('label2') label2: LabelComponent;
  @ViewChild('requiredValidator4') requiredValidator4: RequiredValidatorComponent;
  @ViewChild('name2') name2: TextBoxComponent;
  @ViewChild('label3') label3: LabelComponent;
  @ViewChild('requiredValidator5') requiredValidator5: RequiredValidatorComponent;
  @ViewChild('nameKuerzel') nameKuerzel: TextBoxComponent;
  @ViewChild('label4') label4: LabelComponent;
  @ViewChild('titelVorne') titelVorne: TextBoxComponent;
  @ViewChild('label5') label5: LabelComponent;
  @ViewChild('titelHinten') titelHinten: TextBoxComponent;
  @ViewChild('label6') label6: LabelComponent;
  @ViewChild('strasse') strasse: TextBoxComponent;
  @ViewChild('label17') label17: LabelComponent;
  @ViewChild('plz') plz: TextBoxComponent;
  @ViewChild('label20') label20: LabelComponent;
  @ViewChild('ort') ort: TextBoxComponent;
  @ViewChild('label28') label28: LabelComponent;
  @ViewChild('notiz') notiz: TextAreaComponent;
  @ViewChild('label22') label22: LabelComponent;
  @ViewChild('geburtsdatum') geburtsdatum: DatePickerComponent;
  @ViewChild('label21') label21: LabelComponent;
  @ViewChild('versicherungsnummer') versicherungsnummer: TextBoxComponent;
  @ViewChild('label23') label23: LabelComponent;
  @ViewChild('staatsangehoerigkeit') staatsangehoerigkeit: TextBoxComponent;
  @ViewChild('label24') label24: LabelComponent;
  @ViewChild('telefon1') telefon1: TextBoxComponent;
  @ViewChild('label25') label25: LabelComponent;
  @ViewChild('telefon2') telefon2: TextBoxComponent;
  @ViewChild('label26') label26: LabelComponent;
  @ViewChild('eMail1') eMail1: TextBoxComponent;
  @ViewChild('label27') label27: LabelComponent;
  @ViewChild('eMail2') eMail2: TextBoxComponent;
  @ViewChild('label29') label29: LabelComponent;
  @ViewChild('webseite') webseite: TextBoxComponent;
  @ViewChild('label30') label30: LabelComponent;
  @ViewChild('label31') label31: LabelComponent;
  @ViewChild('kontoName') kontoName: TextBoxComponent;
  @ViewChild('label32') label32: LabelComponent;
  @ViewChild('kontoNummer') kontoNummer: TextBoxComponent;
  @ViewChild('label33') label33: LabelComponent;
  @ViewChild('kontoInfo') kontoInfo: TextAreaComponent;
  @ViewChild('button1') button1: ButtonComponent;
  @ViewChild('button2') button2: ButtonComponent;

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
  dsoBase: any;
  rstBaseAnreden: any;
  parameters: any;

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
    this.dbOptimo.getBaseByBaseId(null, this.parameters.BaseID)
    .subscribe((result: any) => {
      this.dsoBase = result;
    }, (result: any) => {

    });

    this.dbOptimo.getBaseAnredens(null, null, null, null, null, null, null, null)
    .subscribe((result: any) => {
      this.rstBaseAnreden = result.value;
    }, (result: any) => {

    });
  }

  templateFormKontakteSubmit(event: any) {
    this.dbOptimo.updateBase(null, this.dsoBase.BaseID, event)
    .subscribe((result: any) => {
      this.notificationService.notify({ severity: "success", summary: ``, detail: `Kontakt gespeichert` });

      this.dialogRef.close(result);
    }, (result: any) => {
      this.notificationService.notify({ severity: "error", summary: ``, detail: `Kontakt konnte nicht gespeichert werden!` });
    });
  }

  button2Click(event: any) {
    if (this.dialogRef) {
      this.dialogRef.close();
    } else {
      this._location.back();
    }
  }
}