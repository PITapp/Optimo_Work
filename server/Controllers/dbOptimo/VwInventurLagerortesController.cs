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

  [ODataRoutePrefix("odata/dbOptimo/VwInventurLagerortes")]
  [Route("mvc/odata/dbOptimo/VwInventurLagerortes")]
  public partial class VwInventurLagerortesController : ODataController
  {
    private Data.DbOptimoContext context;

    public VwInventurLagerortesController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/VwInventurLagerortes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.VwInventurLagerorte> GetVwInventurLagerortes()
    {
      var items = this.context.VwInventurLagerortes.AsNoTracking().AsQueryable<Models.DbOptimo.VwInventurLagerorte>();
      this.OnVwInventurLagerortesRead(ref items);

      return items;
    }

    partial void OnVwInventurLagerortesRead(ref IQueryable<Models.DbOptimo.VwInventurLagerorte> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{LagerortNummer}")]
    public SingleResult<VwInventurLagerorte> GetVwInventurLagerorte(string key)
    {
        var items = this.context.VwInventurLagerortes.AsNoTracking().Where(i=>i.LagerortNummer == key);
        this.OnVwInventurLagerortesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwInventurLagerortesGet(ref IQueryable<Models.DbOptimo.VwInventurLagerorte> items);

  }
}
