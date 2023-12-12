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
    public string AuftragCode
    {
      get;
      set;
    }
    public int ErfassungNr
    {
      get;
      set;
    }
    public string Lagerort
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
    public string LagerortStatus
    {
      get;
      set;
    }
    public string Verantwortlich
    {
      get;
      set;
    }
    public string Zaehlteam
    {
      get;
      set;
    }
    public string Notiz
    {
      get;
      set;
    }
    public int? DeviceID
    {
      get;
      set;
    }
    public string DeviceNummer
    {
      get;
      set;
    }
    public string DeviceTitel
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
    public string DeviceInfo
    {
      get;
      set;
    }
  }
}
