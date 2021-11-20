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

  [ODataRoutePrefix("odata/dbOptimo/VwBases")]
  [Route("mvc/odata/dbOptimo/VwBases")]
  public partial class VwBasesController : ODataController
  {
    private Data.DbOptimoContext context;

    public VwBasesController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/VwBases
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.VwBase> GetVwBases()
    {
      var items = this.context.VwBases.AsNoTracking().AsQueryable<Models.DbOptimo.VwBase>();
      this.OnVwBasesRead(ref items);

      return items;
    }

    partial void OnVwBasesRead(ref IQueryable<Models.DbOptimo.VwBase> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Name1}")]
    public SingleResult<VwBase> GetVwBase(string key)
    {
        var items = this.context.VwBases.AsNoTracking().Where(i=>i.Name1 == key);
        this.OnVwBasesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwBasesGet(ref IQueryable<Models.DbOptimo.VwBase> items);

  }
}
