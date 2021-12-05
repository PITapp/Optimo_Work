using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimoWork.Models.DbOptimo
{
  [Table("InventurDevice")]
  public partial class InventurDevice
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DeviceID
    {
      get;
      set;
    }


    public ICollection<InventurErfassung> InventurErfassungs { get; set; }
    public string DeviceNummer
    {
      get;
      set;
    }
    public int? InventurID
    {
      get;
      set;
    }

    public InventurBasis InventurBasis { get; set; }
    public string DeviceTitel
    {
      get;
      set;
    }
    public string DeviceTyp
    {
      get;
      set;
    }
    public DateTime? RegistriertAm
    {
      get;
      set;
    }
    public DateTime? AnmeldungAm
    {
      get;
      set;
    }
    public DateTime? AbmeldungAm
    {
      get;
      set;
    }
    public string Info
    {
      get;
      set;
    }
  }
}
