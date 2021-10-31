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

  getVwRollens(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/VwRollens`, { filter, top, skip, orderby, count, expand, format, select });
  }
}
