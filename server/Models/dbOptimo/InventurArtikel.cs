using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimoWork.Models.DbOptimo
{
  [Table("InventurArtikel")]
  public partial class InventurArtikel
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ArtikelID
    {
      get;
      set;
    }


    public ICollection<InventurErfassung> InventurErfassungs { get; set; }
    public int InventurID
    {
      get;
      set;
    }

    public InventurBasis InventurBasis { get; set; }
    public int ZeilenNr
    {
      get;
      set;
    }
    public string Artikelnummer
    {
      get;
      set;
    }
    public string Beschreibung
    {
      get;
      set;
    }
    public string Beschreibung2
    {
      get;
      set;
    }
    public string StdKreditorName
    {
      get;
      set;
    }
    public string ArtikelStatus
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
