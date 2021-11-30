using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimoWork.Models.DbOptimo
{
  [Table("vwErfassungSummen")]
  public partial class VwErfassungSummen
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
    public decimal? Menge
    {
      get;
      set;
    }
  }
}
