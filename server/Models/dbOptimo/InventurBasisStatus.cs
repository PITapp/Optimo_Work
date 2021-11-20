using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimoWork.Models.DbOptimo
{
  [Table("InventurBasisStatus")]
  public partial class InventurBasisStatus
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InventurBasisStatusID
    {
      get;
      set;
    }
    public string LagerortStatus
    {
      get;
      set;
    }


    public ICollection<InventurBasis> InventurBases { get; set; }
    public string IconStatus
    {
      get;
      set;
    }
    public int? Sortierung
    {
      get;
      set;
    }
    public string Notiz
    {
      get;
      set;
    }
  }
}
