using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimoWork.Models.DbOptimo
{
  [Table("vwInventurArtikelKontrolle")]
  public partial class VwInventurArtikelKontrolle
  {
    public int ArtikelID
    {
      get;
      set;
    }
    [Key]
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
    public int? Lagerbestand
    {
      get;
      set;
    }
    public string LagerbestandFormatiert
    {
      get;
      set;
    }
    public double? Einstandspreis
    {
      get;
      set;
    }
    public string EinstandspreisFormatiert
    {
      get;
      set;
    }
    public string ArtikelStatus
    {
      get;
      set;
    }
    public string Notiz
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
    public int InventurID
    {
      get;
      set;
    }
    public string LagerortGesamt
    {
      get;
      set;
    }
    public Int64 AnzahlErfasst
    {
      get;
      set;
    }
    public string AnzahlErfasstFormatiert
    {
      get;
      set;
    }
    public decimal? SummeGezaehlt
    {
      get;
      set;
    }
    public string SummeGezaehltFormatiert
    {
      get;
      set;
    }
    public decimal? AbweichungAbsolut
    {
      get;
      set;
    }
    public string AbweichungAbsolutFormatiert
    {
      get;
      set;
    }
    public decimal? AbweichungProzent
    {
      get;
      set;
    }
    public string AbweichungProzentFormatiert
    {
      get;
      set;
    }
    public double? WertkorrekturDurchInventur
    {
      get;
      set;
    }
    public string WertkorrekturDurchInventurFormatiert
    {
      get;
      set;
    }
  }
}
