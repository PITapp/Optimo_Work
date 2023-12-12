using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimoWork.Models.DbOptimo
{
  [Table("vwErfassungNAV")]
  public partial class VwErfassungNav
  {
    [Key]
    public string Auftragsnr
    {
      get;
      set;
    }
    public int Erfassungsnr
    {
      get;
      set;
    }
    public int Zeilennr
    {
      get;
      set;
    }
    public string Artikelnummer
    {
      get;
      set;
    }
    public decimal? Menge
    {
      get;
      set;
    }
  }
}
