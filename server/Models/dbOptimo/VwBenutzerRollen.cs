using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimoWork.Models.DbOptimo
{
  [Table("vwBenutzerRollen")]
  public partial class VwBenutzerRollen
  {
    public int BenutzerID
    {
      get;
      set;
    }
    [Key]
    public string AspNetUsers_Id
    {
      get;
      set;
    }
    public int BaseID
    {
      get;
      set;
    }
    public string Benutzername
    {
      get;
      set;
    }
    public string Initialen
    {
      get;
      set;
    }
    public string BenutzerEMail
    {
      get;
      set;
    }
    public string Notiz
    {
      get;
      set;
    }
    public int? LetzteBaseID
    {
      get;
      set;
    }
    public int? LetzteBenutzerID
    {
      get;
      set;
    }
    public string RoleId
    {
      get;
      set;
    }
    public string RolleTitel
    {
      get;
      set;
    }
  }
}
