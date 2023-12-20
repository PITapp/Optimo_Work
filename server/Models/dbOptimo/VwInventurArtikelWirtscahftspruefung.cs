using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimoWork.Models.DbOptimo
{
  [Table("vwInventurArtikelWirtscahftspruefung")]
  public partial class VwInventurArtikelWirtscahftspruefung
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
    public string Lagerort
    {
      get;
      set;
    }
    public decimal? Gezaehlt
    {
      get;
      set;
    }
  }
}
