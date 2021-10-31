using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimoWork.Models.DbOptimo
{
  [Table("vwBasePlz")]
  public partial class VwBasePlz
  {
    [Key]
    public string PLZ
    {
      get;
      set;
    }
  }
}
