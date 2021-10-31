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

  [ODataRoutePrefix("odata/dbOptimo/VwBaseAlles")]
  [Route("mvc/odata/dbOptimo/VwBaseAlles")]
  public partial class VwBaseAllesController : ODataController
  {
    private Data.DbOptimoContext context;

    public VwBaseAllesController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/VwBaseAlles
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.VwBaseAlle> GetVwBaseAlles()
    {
      var items = this.context.VwBaseAlles.AsNoTracking().AsQueryable<Models.DbOptimo.VwBaseAlle>();
      this.OnVwBaseAllesRead(ref items);

      return items;
    }

    partial void OnVwBaseAllesRead(ref IQueryable<Models.DbOptimo.VwBaseAlle> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Name1}")]
    public SingleResult<VwBaseAlle> GetVwBaseAlle(string key)
    {
        var items = this.context.VwBaseAlles.AsNoTracking().Where(i=>i.Name1 == key);
        this.OnVwBaseAllesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwBaseAllesGet(ref IQueryable<Models.DbOptimo.VwBaseAlle> items);

  }
}
