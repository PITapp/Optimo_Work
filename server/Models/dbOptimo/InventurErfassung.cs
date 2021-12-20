using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimoWork.Models.DbOptimo
{
  [Table("InventurErfassung")]
  public partial class InventurErfassung
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ErfassungID
    {
      get;
      set;
    }
    public int ArtikelID
    {
      get;
      set;
    }

    public InventurArtikel InventurArtikel { get; set; }
    public int DeviceID
    {
      get;
      set;
    }

    public InventurDevice InventurDevice { get; set; }
    public DateTime ErfasstAm
    {
      get;
      set;
    }
    public int ErfasstAnzahl
    {
      get;
      set;
    }
    public string GescannteDaten
    {
      get;
      set;
    }
    public DateTime? GeloeschtAm
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
