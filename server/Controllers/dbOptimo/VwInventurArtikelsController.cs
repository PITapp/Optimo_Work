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

  [ODataRoutePrefix("odata/dbOptimo/VwInventurArtikels")]
  [Route("mvc/odata/dbOptimo/VwInventurArtikels")]
  public partial class VwInventurArtikelsController : ODataController
  {
    private Data.DbOptimoContext context;

    public VwInventurArtikelsController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/VwInventurArtikels
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.VwInventurArtikel> GetVwInventurArtikels()
    {
      var items = this.context.VwInventurArtikels.AsNoTracking().AsQueryable<Models.DbOptimo.VwInventurArtikel>();
      this.OnVwInventurArtikelsRead(ref items);

      return items;
    }

    partial void OnVwInventurArtikelsRead(ref IQueryable<Models.DbOptimo.VwInventurArtikel> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Artikelnummer}")]
    public SingleResult<VwInventurArtikel> GetVwInventurArtikel(string key)
    {
        var items = this.context.VwInventurArtikels.AsNoTracking().Where(i=>i.Artikelnummer == key);
        this.OnVwInventurArtikelsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwInventurArtikelsGet(ref IQueryable<Models.DbOptimo.VwInventurArtikel> items);

  }
}
