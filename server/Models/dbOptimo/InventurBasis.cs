using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimoWork.Models.DbOptimo
{
  [Table("InventurBasis")]
  public partial class InventurBasis
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InventurID
    {
      get;
      set;
    }


    public ICollection<InventurDevice> InventurDevices { get; set; }

    public ICollection<InventurErfassung> InventurErfassungs { get; set; }
    public string LagerortStatus
    {
      get;
      set;
    }

    public InventurBasisStatus InventurBasisStatus { get; set; }
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
    public string Beschreibung
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
    public string FilterBC
    {
      get;
      set;
    }
    public string FilterAccess
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
