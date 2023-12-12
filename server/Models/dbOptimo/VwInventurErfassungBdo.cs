using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimoWork.Models.DbOptimo
{
  [Table("vwInventurErfassungBDO")]
  public partial class VwInventurErfassungBdo
  {
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
    public string ErfasstAnzahlFormatiert
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
    public DateTime? GeloeschtAm
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
  }
}
