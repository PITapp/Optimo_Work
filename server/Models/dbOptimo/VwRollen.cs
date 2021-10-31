using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimoWork.Models.DbOptimo
{
  [Table("vwRollen")]
  public partial class VwRollen
  {
    [Key]
    public string Id
    {
      get;
      set;
    }
    public string Titel
    {
      get;
      set;
    }
  }
}
