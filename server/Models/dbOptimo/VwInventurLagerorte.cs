using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimoWork.Models.DbOptimo
{
  [Table("vwInventurLagerorte")]
  public partial class VwInventurLagerorte
  {
    public int InventurID
    {
      get;
      set;
    }
    [Key]
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
    public string LagerortStatus
    {
      get;
      set;
    }
    public Int64 AnzahlArtikel
    {
      get;
      set;
    }
    public Int64 AnzahlErfasst
    {
      get;
      set;
    }
  }
}
