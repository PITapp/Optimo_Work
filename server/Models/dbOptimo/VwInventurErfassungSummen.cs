using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimoWork.Models.DbOptimo
{
  [Table("vwInventurErfassungSummen")]
  public partial class VwInventurErfassungSummen
  {
    [Key]
    public int ArtikelID
    {
      get;
      set;
    }
    public decimal? SummeErfasst
    {
      get;
      set;
    }
    public string SummeErfasstFormatiert
    {
      get;
      set;
    }
  }
}
