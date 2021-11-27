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

  [ODataRoutePrefix("odata/dbOptimo/VwInventurLagerorteMitSummens")]
  [Route("mvc/odata/dbOptimo/VwInventurLagerorteMitSummens")]
  public partial class VwInventurLagerorteMitSummensController : ODataController
  {
    private Data.DbOptimoContext context;

    public VwInventurLagerorteMitSummensController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/VwInventurLagerorteMitSummens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.VwInventurLagerorteMitSummen> GetVwInventurLagerorteMitSummens()
    {
      var items = this.context.VwInventurLagerorteMitSummens.AsNoTracking().AsQueryable<Models.DbOptimo.VwInventurLagerorteMitSummen>();
      this.OnVwInventurLagerorteMitSummensRead(ref items);

      return items;
    }

    partial void OnVwInventurLagerorteMitSummensRead(ref IQueryable<Models.DbOptimo.VwInventurLagerorteMitSummen> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{LagerortNummer}")]
    public SingleResult<VwInventurLagerorteMitSummen> GetVwInventurLagerorteMitSummen(string key)
    {
        var items = this.context.VwInventurLagerorteMitSummens.AsNoTracking().Where(i=>i.LagerortNummer == key);
        this.OnVwInventurLagerorteMitSummensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwInventurLagerorteMitSummensGet(ref IQueryable<Models.DbOptimo.VwInventurLagerorteMitSummen> items);

  }
}
