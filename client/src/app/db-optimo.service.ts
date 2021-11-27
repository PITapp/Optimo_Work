import { Injectable } from '@angular/core';
import { Location } from '@angular/common';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, BehaviorSubject, throwError } from 'rxjs';

import { ConfigService } from './config.service';
import { ODataClient } from './odata-client';
import * as models from './db-optimo.model';

@Injectable()
export class DbOptimoService {
  odata: ODataClient;
  basePath: string;

  constructor(private http: HttpClient, private config: ConfigService) {
    this.basePath = config.get('dbOptimo');
    this.odata = new ODataClient(this.http, this.basePath, { legacy: false, withCredentials: true });
  }

  getBases(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/Bases`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createBase(expand: string | null, base: models.Base | null) : Observable<any> {
    return this.odata.post(`/Bases`, base, { expand }, ['BaseAnreden']);
  }

  deleteBase(baseId: number | null) : Observable<any> {
    return this.odata.delete(`/Bases(${baseId})`, item => !(item.BaseID == baseId));
  }

  getBaseByBaseId(expand: string | null, baseId: number | null) : Observable<any> {
    return this.odata.getById(`/Bases(${baseId})`, { expand });
  }

  updateBase(expand: string | null, baseId: number | null, base: models.Base | null) : Observable<any> {
    return this.odata.patch(`/Bases(${baseId})`, base, item => item.BaseID == baseId, { expand }, ['BaseAnreden']);
  }

  getBaseAnredens(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/BaseAnredens`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createBaseAnreden(expand: string | null, baseAnreden: models.BaseAnreden | null) : Observable<any> {
    return this.odata.post(`/BaseAnredens`, baseAnreden, { expand }, []);
  }

  deleteBaseAnreden(anredeId: number | null) : Observable<any> {
    return this.odata.delete(`/BaseAnredens(${anredeId})`, item => !(item.AnredeID == anredeId));
  }

  getBaseAnredenByAnredeId(expand: string | null, anredeId: number | null) : Observable<any> {
    return this.odata.getById(`/BaseAnredens(${anredeId})`, { expand });
  }

  updateBaseAnreden(expand: string | null, anredeId: number | null, baseAnreden: models.BaseAnreden | null) : Observable<any> {
    return this.odata.patch(`/BaseAnredens(${anredeId})`, baseAnreden, item => item.AnredeID == anredeId, { expand }, []);
  }

  getBaseKontaktes(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/BaseKontaktes`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createBaseKontakte(expand: string | null, baseKontakte: models.BaseKontakte | null) : Observable<any> {
    return this.odata.post(`/BaseKontaktes`, baseKontakte, { expand }, ['Base']);
  }

  deleteBaseKontakte(kontaktId: number | null) : Observable<any> {
    return this.odata.delete(`/BaseKontaktes(${kontaktId})`, item => !(item.KontaktID == kontaktId));
  }

  getBaseKontakteByKontaktId(expand: string | null, kontaktId: number | null) : Observable<any> {
    return this.odata.getById(`/BaseKontaktes(${kontaktId})`, { expand });
  }

  updateBaseKontakte(expand: string | null, kontaktId: number | null, baseKontakte: models.BaseKontakte | null) : Observable<any> {
    return this.odata.patch(`/BaseKontaktes(${kontaktId})`, baseKontakte, item => item.KontaktID == kontaktId, { expand }, ['Base']);
  }

  getBenutzers(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/Benutzers`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createBenutzer(expand: string | null, benutzer: models.Benutzer | null) : Observable<any> {
    return this.odata.post(`/Benutzers`, benutzer, { expand }, ['Base']);
  }

  deleteBenutzer(benutzerId: number | null) : Observable<any> {
    return this.odata.delete(`/Benutzers(${benutzerId})`, item => !(item.BenutzerID == benutzerId));
  }

  getBenutzerByBenutzerId(expand: string | null, benutzerId: number | null) : Observable<any> {
    return this.odata.getById(`/Benutzers(${benutzerId})`, { expand });
  }

  updateBenutzer(expand: string | null, benutzerId: number | null, benutzer: models.Benutzer | null) : Observable<any> {
    return this.odata.patch(`/Benutzers(${benutzerId})`, benutzer, item => item.BenutzerID == benutzerId, { expand }, ['Base']);
  }

  getInfotexteHtmls(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/InfotexteHtmls`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createInfotexteHtml(expand: string | null, infotexteHtml: models.InfotexteHtml | null) : Observable<any> {
    return this.odata.post(`/InfotexteHtmls`, infotexteHtml, { expand }, []);
  }

  deleteInfotexteHtml(infotextId: number | null) : Observable<any> {
    return this.odata.delete(`/InfotexteHtmls(${infotextId})`, item => !(item.InfotextID == infotextId));
  }

  getInfotexteHtmlByInfotextId(expand: string | null, infotextId: number | null) : Observable<any> {
    return this.odata.getById(`/InfotexteHtmls(${infotextId})`, { expand });
  }

  updateInfotexteHtml(expand: string | null, infotextId: number | null, infotexteHtml: models.InfotexteHtml | null) : Observable<any> {
    return this.odata.patch(`/InfotexteHtmls(${infotextId})`, infotexteHtml, item => item.InfotextID == infotextId, { expand }, []);
  }

  getInventurArtikels(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/InventurArtikels`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createInventurArtikel(expand: string | null, inventurArtikel: models.InventurArtikel | null) : Observable<any> {
    return this.odata.post(`/InventurArtikels`, inventurArtikel, { expand }, ['InventurBasis']);
  }

  deleteInventurArtikel(artikelId: number | null) : Observable<any> {
    return this.odata.delete(`/InventurArtikels(${artikelId})`, item => !(item.ArtikelID == artikelId));
  }

  getInventurArtikelByArtikelId(expand: string | null, artikelId: number | null) : Observable<any> {
    return this.odata.getById(`/InventurArtikels(${artikelId})`, { expand });
  }

  updateInventurArtikel(expand: string | null, artikelId: number | null, inventurArtikel: models.InventurArtikel | null) : Observable<any> {
    return this.odata.patch(`/InventurArtikels(${artikelId})`, inventurArtikel, item => item.ArtikelID == artikelId, { expand }, ['InventurBasis']);
  }

  getInventurBases(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/InventurBases`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createInventurBasis(expand: string | null, inventurBasis: models.InventurBasis | null) : Observable<any> {
    return this.odata.post(`/InventurBases`, inventurBasis, { expand }, ['InventurBasisStatus']);
  }

  deleteInventurBasis(inventurId: number | null) : Observable<any> {
    return this.odata.delete(`/InventurBases(${inventurId})`, item => !(item.InventurID == inventurId));
  }

  getInventurBasisByInventurId(expand: string | null, inventurId: number | null) : Observable<any> {
    return this.odata.getById(`/InventurBases(${inventurId})`, { expand });
  }

  updateInventurBasis(expand: string | null, inventurId: number | null, inventurBasis: models.InventurBasis | null) : Observable<any> {
    return this.odata.patch(`/InventurBases(${inventurId})`, inventurBasis, item => item.InventurID == inventurId, { expand }, ['InventurBasisStatus']);
  }

  getInventurBasisStatuses(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/InventurBasisStatuses`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createInventurBasisStatus(expand: string | null, inventurBasisStatus: models.InventurBasisStatus | null) : Observable<any> {
    return this.odata.post(`/InventurBasisStatuses`, inventurBasisStatus, { expand }, []);
  }

  deleteInventurBasisStatus(inventurBasisStatusId: number | null) : Observable<any> {
    return this.odata.delete(`/InventurBasisStatuses(${inventurBasisStatusId})`, item => !(item.InventurBasisStatusID == inventurBasisStatusId));
  }

  getInventurBasisStatusByInventurBasisStatusId(expand: string | null, inventurBasisStatusId: number | null) : Observable<any> {
    return this.odata.getById(`/InventurBasisStatuses(${inventurBasisStatusId})`, { expand });
  }

  updateInventurBasisStatus(expand: string | null, inventurBasisStatusId: number | null, inventurBasisStatus: models.InventurBasisStatus | null) : Observable<any> {
    return this.odata.patch(`/InventurBasisStatuses(${inventurBasisStatusId})`, inventurBasisStatus, item => item.InventurBasisStatusID == inventurBasisStatusId, { expand }, []);
  }

  getInventurDevices(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/InventurDevices`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createInventurDevice(expand: string | null, inventurDevice: models.InventurDevice | null) : Observable<any> {
    return this.odata.post(`/InventurDevices`, inventurDevice, { expand }, ['InventurBasis']);
  }

  deleteInventurDevice(deviceId: number | null) : Observable<any> {
    return this.odata.delete(`/InventurDevices(${deviceId})`, item => !(item.DeviceID == deviceId));
  }

  getInventurDeviceByDeviceId(expand: string | null, deviceId: number | null) : Observable<any> {
    return this.odata.getById(`/InventurDevices(${deviceId})`, { expand });
  }

  updateInventurDevice(expand: string | null, deviceId: number | null, inventurDevice: models.InventurDevice | null) : Observable<any> {
    return this.odata.patch(`/InventurDevices(${deviceId})`, inventurDevice, item => item.DeviceID == deviceId, { expand }, ['InventurBasis']);
  }

  getInventurErfassungs(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/InventurErfassungs`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createInventurErfassung(expand: string | null, inventurErfassung: models.InventurErfassung | null) : Observable<any> {
    return this.odata.post(`/InventurErfassungs`, inventurErfassung, { expand }, ['InventurArtikel', 'InventurDevice']);
  }

  deleteInventurErfassung(erfassungId: number | null) : Observable<any> {
    return this.odata.delete(`/InventurErfassungs(${erfassungId})`, item => !(item.ErfassungID == erfassungId));
  }

  getInventurErfassungByErfassungId(expand: string | null, erfassungId: number | null) : Observable<any> {
    return this.odata.getById(`/InventurErfassungs(${erfassungId})`, { expand });
  }

  updateInventurErfassung(expand: string | null, erfassungId: number | null, inventurErfassung: models.InventurErfassung | null) : Observable<any> {
    return this.odata.patch(`/InventurErfassungs(${erfassungId})`, inventurErfassung, item => item.ErfassungID == erfassungId, { expand }, ['InventurArtikel','InventurDevice']);
  }

  getNotizens(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/Notizens`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createNotizen(expand: string | null, notizen: models.Notizen | null) : Observable<any> {
    return this.odata.post(`/Notizens`, notizen, { expand }, []);
  }

  deleteNotizen(notizId: number | null) : Observable<any> {
    return this.odata.delete(`/Notizens(${notizId})`, item => !(item.NotizID == notizId));
  }

  getNotizenByNotizId(expand: string | null, notizId: number | null) : Observable<any> {
    return this.odata.getById(`/Notizens(${notizId})`, { expand });
  }

  updateNotizen(expand: string | null, notizId: number | null, notizen: models.Notizen | null) : Observable<any> {
    return this.odata.patch(`/Notizens(${notizId})`, notizen, item => item.NotizID == notizId, { expand }, []);
  }

  getProtokolls(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/Protokolls`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createProtokoll(expand: string | null, protokoll: models.Protokoll | null) : Observable<any> {
    return this.odata.post(`/Protokolls`, protokoll, { expand }, ['Base']);
  }

  deleteProtokoll(protokollId: number | null) : Observable<any> {
    return this.odata.delete(`/Protokolls(${protokollId})`, item => !(item.ProtokollID == protokollId));
  }

  getProtokollByProtokollId(expand: string | null, protokollId: number | null) : Observable<any> {
    return this.odata.getById(`/Protokolls(${protokollId})`, { expand });
  }

  updateProtokoll(expand: string | null, protokollId: number | null, protokoll: models.Protokoll | null) : Observable<any> {
    return this.odata.patch(`/Protokolls(${protokollId})`, protokoll, item => item.ProtokollID == protokollId, { expand }, ['Base']);
  }

  getVwBases(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/VwBases`, { filter, top, skip, orderby, count, expand, format, select });
  }

  getVwBaseAlles(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/VwBaseAlles`, { filter, top, skip, orderby, count, expand, format, select });
  }

  getVwBaseKontaktes(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/VwBaseKontaktes`, { filter, top, skip, orderby, count, expand, format, select });
  }

  getVwBaseOrtes(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/VwBaseOrtes`, { filter, top, skip, orderby, count, expand, format, select });
  }

  getVwBasePlzs(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/VwBasePlzs`, { filter, top, skip, orderby, count, expand, format, select });
  }

  getVwBenutzerBases(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/VwBenutzerBases`, { filter, top, skip, orderby, count, expand, format, select });
  }

  getVwBenutzerRollens(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/VwBenutzerRollens`, { filter, top, skip, orderby, count, expand, format, select });
  }

  getVwInventurArtikels(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/VwInventurArtikels`, { filter, top, skip, orderby, count, expand, format, select });
  }

  getVwInventurErfassungs(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/VwInventurErfassungs`, { filter, top, skip, orderby, count, expand, format, select });
  }

  getVwInventurLagerortes(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/VwInventurLagerortes`, { filter, top, skip, orderby, count, expand, format, select });
  }

  getVwInventurLagerorteMitSummens(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/VwInventurLagerorteMitSummens`, { filter, top, skip, orderby, count, expand, format, select });
  }

  getVwRollens(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/VwRollens`, { filter, top, skip, orderby, count, expand, format, select });
  }
}
