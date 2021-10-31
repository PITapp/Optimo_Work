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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNet.OData.Query;



namespace OptimoWork.Controllers.DbOptimo
{
  using Models;
  using Data;
  using Models.DbOptimo;

  [ODataRoutePrefix("odata/dbOptimo/VwRollens")]
  [Route("mvc/odata/dbOptimo/VwRollens")]
  public partial class VwRollensController : ODataController
  {
    private Data.DbOptimoContext context;

    public VwRollensController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/VwRollens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.VwRollen> GetVwRollens()
    {
      var items = this.context.VwRollens.AsNoTracking().AsQueryable<Models.DbOptimo.VwRollen>();
      this.OnVwRollensRead(ref items);

      return items;
    }

    partial void OnVwRollensRead(ref IQueryable<Models.DbOptimo.VwRollen> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Id}")]
    public SingleResult<VwRollen> GetVwRollen(string key)
    {
        var items = this.context.VwRollens.AsNoTracking().Where(i=>i.Id == key);
        this.OnVwRollensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwRollensGet(ref IQueryable<Models.DbOptimo.VwRollen> items);

  }
}
