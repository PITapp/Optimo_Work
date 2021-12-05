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
  Beschreibung2: string;
  StdKreditorName: string;
  ArtikelStatus: string;
  Notiz: string;
}

export interface InventurBasis {
  InventurID: number;
  LagerortStatus: string;
  AuftragCode: string;
  ErfassungNr: number;
  Lagerort: string;
  Beschreibung: string;
  LagerortNummer: string;
  LagerortTitel: string;
  Verantwortlich: string;
  Notiz: string;
}

export interface InventurBasisStatus {
  InventurBasisStatusID: number;
  LagerortStatus: string;
  IconStatus: string;
  Sortierung: number;
  Notiz: string;
}

export interface InventurDevice {
  DeviceID: number;
  DeviceNummer: string;
  InventurID: number;
  DeviceTitel: string;
  DeviceTyp: string;
  RegistriertAm: string;
  AnmeldungAm: string;
  AbmeldungAm: string;
  Info: string;
}

export interface InventurErfassung {
  ErfassungID: number;
  ArtikelID: number;
  DeviceID: number;
  ErfasstAm: string;
  ErfasstAnzahl: number;
  GeloeschtAm: string;
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

export interface VwErfassungSummen {
  Auftragsnr: string;
  Erfassungsnr: number;
  Zeilennr: number;
  Menge: number;
}

export interface VwInventurArtikel {
  ArtikelID: number;
  InventurID: number;
  Artikelnummer: string;
  Beschreibung: string;
  Beschreibung2: string;
  StdKreditorName: string;
  ArtikelStatus: string;
  Notiz: string;
  LagerortNummer: string;
  LagerortTitel: string;
  LagerortGesamt: string;
  AnzahlErfasst: number;
  SummeGezaehlt: number;
  AnzahlErfasstFormatiert: string;
  SummeGezaehltFormatiert: string;
}

export interface VwInventurArtikelAlle {
  ArtikelID: number;
  InventurID: number;
  ZeilenNr: number;
  Artikelnummer: string;
  Beschreibung: string;
  Beschreibung2: string;
  StdKreditorName: string;
  ArtikelStatus: string;
  Notiz: string;
}

export interface VwInventurErfassung {
  ErfassungID: number;
  ArtikelID: number;
  DeviceID: number;
  ErfasstAm: string;
  ErfasstAmFormatiert: string;
  ErfasstAnzahl: number;
  ErfasstAnzahlFormatiert: string;
  GeloeschtAm: string;
  InventurID: number;
  Artikelnummer: string;
  Beschreibung: string;
  Beschreibung2: string;
  StdKreditorName: string;
  LagerortNummer: string;
  LagerortTitel: string;
  LagerortGesamt: string;
  DeviceNummer: string;
  DeviceTitel: string;
  RegistriertAm: string;
  AnmeldungAm: string;
  AbmeldungAm: string;
}

export interface VwInventurErfassungSummen {
  ArtikelID: number;
  SummeErfasst: number;
  SummeErfasstFormatiert: string;
}

export interface VwInventurLagerorte {
  InventurID: number;
  LagerortNummer: string;
  LagerortTitel: string;
  LagerortStatus: string;
  Notiz: string;
  DeviceID: number;
  DeviceNummer: string;
  DeviceTitel: string;
  RegistriertAm: string;
  AnmeldungAm: string;
  AbmeldungAm: string;
  DeviceInfo: string;
}

export interface VwInventurLagerorteMitSummen {
  InventurID: number;
  LagerortNummer: string;
  LagerortTitel: string;
  LagerortGesamt: string;
  LagerortStatus: string;
  AnzahlArtikel: number;
  AnzahlErfasst: number;
  AnzahlArtikelFormatiert: string;
  AnzahlErfasstFormatiert: string;
}

export interface VwRollen {
  Id: string;
  Titel: string;
}
