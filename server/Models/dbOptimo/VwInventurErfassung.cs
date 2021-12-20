using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimoWork.Models.DbOptimo
{
  [Table("vwInventurErfassung")]
  public partial class VwInventurErfassung
  {
    public int ErfassungID
    {
      get;
      set;
    }
    [Key]
    public int ArtikelID
    {
      get;
      set;
    }
    public int DeviceID
    {
      get;
      set;
    }
    public DateTime ErfasstAm
    {
      get;
      set;
    }
    public string ErfasstAmFormatiert
    {
      get;
      set;
    }
    public int ErfasstAnzahl
    {
      get;
      set;
    }
    public string ErfasstAnzahlFormatiert
    {
      get;
      set;
    }
    public string GescannteDaten
    {
      get;
      set;
    }
    public DateTime? GeloeschtAm
    {
      get;
      set;
    }
    public int InventurID
    {
      get;
      set;
    }
    public string Artikelnummer
    {
      get;
      set;
    }
    public string Beschreibung
    {
      get;
      set;
    }
    public string Beschreibung2
    {
      get;
      set;
    }
    public string StdKreditorName
    {
      get;
      set;
    }
    public string LagerortNummer
    {
      get;
      set;
    }
    public string LagerortTitel
    {
      get;
      set;
    }
    public string LagerortGesamt
    {
      get;
      set;
    }
    public string DeviceNummer
    {
      get;
      set;
    }
    public string DeviceTitel
    {
      get;
      set;
    }
    public DateTime? RegistriertAm
    {
      get;
      set;
    }
    public DateTime? AnmeldungAm
    {
      get;
      set;
    }
    public DateTime? AbmeldungAm
    {
      get;
      set;
    }
  }
}
