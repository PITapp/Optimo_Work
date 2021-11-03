export interface Base {
  BaseID: number;
  AnredeID: number;
  Name1: string;
  Name2: string;
  NameKuerzel: string;
  TitelVorne: string;
  TitelHinten: string;
  Strasse: string;
  PLZ: string;
  Ort: string;
  Geburtsdatum: string;
  Versicherungsnummer: string;
  Staatsangehoerigkeit: string;
  Telefon1: string;
  Telefon2: string;
  EMail1: string;
  EMail2: string;
  Webseite: string;
  BildURL: string;
  Notiz: string;
  KontoName: string;
  KontoNummer: string;
  KontoInfo: string;
}

export interface BaseAnreden {
  AnredeID: number;
  Anrede: string;
}

export interface BaseKontakte {
  KontaktID: number;
  BaseID: number;
  NameKontakt: string;
  Handy: string;
  Telefon: string;
  EMail: string;
  Info: string;
}

export interface Benutzer {
  BenutzerID: number;
  BaseID: number;
  AspNetUsers_Id: string;
  Benutzername: string;
  Initialen: string;
  BenutzerEMail: string;
  Notiz: string;
  LetzteBaseID: number;
  LetzteBenutzerID: number;
}

export interface InfotexteHtml {
  InfotextID: number;
  Code: string;
  Titel: string;
  Inhalt: string;
  Sortierung: number;
}

export interface InventurArtikel {
  ArtikelID: number;
  InventurID: number;
  ZeilenNr: number;
  Artikelnummer: string;
  Beschreibung: string;
  Status: string;
  Notiz: string;
}

export interface InventurBasis {
  InventurID: number;
  AuftragCode: string;
  ErfassungNr: number;
  Lagerort: string;
  Beschreibung: string;
  Status: string;
  Verantwortlich: string;
  Notiz: string;
}

export interface InventurErfassung {
  ErfassungID: number;
  BenutzerID: number;
  ArtikelID: number;
  ErfasstAm: string;
  ErfasstAnzahl: number;
  Notiz: string;
}

export interface Notizen {
  NotizID: number;
  LinkID: number;
  Am: string;
  Titel: string;
  Notiz: string;
}

export interface Protokoll {
  ProtokollID: number;
  BaseID: number;
  ErstelltAm: string;
  Art: string;
  Bereich: string;
  Titel: string;
  Beschreibung: string;
  ManagementZeigen: number;
  LinkID: number;
  Gelesen: boolean;
  GelesenAm: string;
}

export interface VwBase {
  BaseID: number;
  Name1: string;
  Name2: string;
  NameKuerzel: string;
  AnredeID: number;
  TitelVorne: string;
  TitelHinten: string;
  Strasse: string;
  PLZ: string;
  Ort: string;
  Geburtsdatum: string;
  Versicherungsnummer: string;
  Staatsangehoerigkeit: string;
  Telefon1: string;
  Telefon2: string;
  EMail1: string;
  EMail2: string;
  Webseite: string;
  BildURL: string;
  Notiz: string;
  KontoName: string;
  KontoNummer: string;
  KontoInfo: string;
  NameGesamt: string;
}

export interface VwBaseAlle {
  BaseID: number;
  Name1: string;
  Name2: string;
  NameKuerzel: string;
  AnredeID: number;
  TitelVorne: string;
  TitelHinten: string;
  Strasse: string;
  PLZ: string;
  Ort: string;
  Geburtsdatum: string;
  Versicherungsnummer: string;
  Staatsangehoerigkeit: string;
  Telefon1: string;
  Telefon2: string;
  EMail1: string;
  EMail2: string;
  Webseite: string;
  BildURL: string;
  Notiz: string;
  KontoName: string;
  KontoNummer: string;
  KontoInfo: string;
  NameGesamt: string;
}

export interface VwBaseKontakte {
  BaseID: number;
  Name1: string;
  Name2: string;
  NameGesamt: string;
  NameKuerzel: string;
  AnredeID: number;
  Anrede: string;
  TitelVorne: string;
  TitelHinten: string;
  Strasse: string;
  PLZ: string;
  Ort: string;
  Geburtsdatum: string;
  Versicherungsnummer: string;
  Staatsangehoerigkeit: string;
  Telefon1: string;
  Telefon2: string;
  EMail1: string;
  EMail2: string;
  Webseite: string;
  BildURL: string;
  Notiz: string;
  KontoName: string;
  KontoNummer: string;
  KontoInfo: string;
}

export interface VwBaseOrte {
  Ort: string;
}

export interface VwBasePlz {
  PLZ: string;
}

export interface VwBenutzerBase {
  BenutzerID: number;
  AspNetUsers_Id: string;
  BaseID: number;
  Benutzername: string;
  Initialen: string;
  BenutzerEMail: string;
  Notiz: string;
  Name1: string;
  Name2: string;
  NameGesamt: string;
  NameKuerzel: string;
  AnredeID: number;
  TitelVorne: string;
  TitelHinten: string;
  Strasse: string;
  PLZ: string;
  Ort: string;
  Geburtsdatum: string;
  Versicherungsnummer: string;
  Staatsangehoerigkeit: string;
  Telefon1: string;
  Telefon2: string;
  EMail1: string;
  EMail2: string;
  Webseite: string;
  BildURL: string;
  BaseNotiz: string;
}

export interface VwBenutzerRollen {
  BenutzerID: number;
  AspNetUsers_Id: string;
  BaseID: number;
  Benutzername: string;
  Initialen: string;
  BenutzerEMail: string;
  Notiz: string;
  LetzteBaseID: number;
  LetzteBenutzerID: number;
  RoleId: string;
  RolleTitel: string;
}

export interface VwRollen {
  Id: string;
  Titel: string;
}
