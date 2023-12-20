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

  [ODataRoutePrefix("odata/dbOptimo/VwInventurArtikelKontrolles")]
  [Route("mvc/odata/dbOptimo/VwInventurArtikelKontrolles")]
  public partial class VwInventurArtikelKontrollesController : ODataController
  {
    private Data.DbOptimoContext context;

    public VwInventurArtikelKontrollesController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/VwInventurArtikelKontrolles
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.VwInventurArtikelKontrolle> GetVwInventurArtikelKontrolles()
    {
      var items = this.context.VwInventurArtikelKontrolles.AsNoTracking().AsQueryable<Models.DbOptimo.VwInventurArtikelKontrolle>();
      this.OnVwInventurArtikelKontrollesRead(ref items);

      return items;
    }

    partial void OnVwInventurArtikelKontrollesRead(ref IQueryable<Models.DbOptimo.VwInventurArtikelKontrolle> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Artikelnummer}")]
    public SingleResult<VwInventurArtikelKontrolle> GetVwInventurArtikelKontrolle(string key)
    {
        var items = this.context.VwInventurArtikelKontrolles.AsNoTracking().Where(i=>i.Artikelnummer == key);
        this.OnVwInventurArtikelKontrollesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwInventurArtikelKontrollesGet(ref IQueryable<Models.DbOptimo.VwInventurArtikelKontrolle> items);

  }
}
