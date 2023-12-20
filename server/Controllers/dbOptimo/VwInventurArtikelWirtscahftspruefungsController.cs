using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNet.OData.Query;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;



namespace OptimoWork.Controllers.DbOptimo
{
  using Models;
  using Data;
  using Models.DbOptimo;

  [ODataRoutePrefix("odata/dbOptimo/VwInventurArtikelWirtscahftspruefungs")]
  [Route("mvc/odata/dbOptimo/VwInventurArtikelWirtscahftspruefungs")]
  public partial class VwInventurArtikelWirtscahftspruefungsController : ODataController
  {
    private Data.DbOptimoContext context;

    public VwInventurArtikelWirtscahftspruefungsController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/VwInventurArtikelWirtscahftspruefungs
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.VwInventurArtikelWirtscahftspruefung> GetVwInventurArtikelWirtscahftspruefungs()
    {
      var items = this.context.VwInventurArtikelWirtscahftspruefungs.AsNoTracking().AsQueryable<Models.DbOptimo.VwInventurArtikelWirtscahftspruefung>();
      this.OnVwInventurArtikelWirtscahftspruefungsRead(ref items);

      return items;
    }

    partial void OnVwInventurArtikelWirtscahftspruefungsRead(ref IQueryable<Models.DbOptimo.VwInventurArtikelWirtscahftspruefung> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Artikelnummer}")]
    public SingleResult<VwInventurArtikelWirtscahftspruefung> GetVwInventurArtikelWirtscahftspruefung(string key)
    {
        var items = this.context.VwInventurArtikelWirtscahftspruefungs.AsNoTracking().Where(i=>i.Artikelnummer == key);
        this.OnVwInventurArtikelWirtscahftspruefungsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwInventurArtikelWirtscahftspruefungsGet(ref IQueryable<Models.DbOptimo.VwInventurArtikelWirtscahftspruefung> items);

  }
}
