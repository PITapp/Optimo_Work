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

  [ODataRoutePrefix("odata/dbOptimo/VwBaseOrtes")]
  [Route("mvc/odata/dbOptimo/VwBaseOrtes")]
  public partial class VwBaseOrtesController : ODataController
  {
    private Data.DbOptimoContext context;

    public VwBaseOrtesController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/VwBaseOrtes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.VwBaseOrte> GetVwBaseOrtes()
    {
      var items = this.context.VwBaseOrtes.AsNoTracking().AsQueryable<Models.DbOptimo.VwBaseOrte>();
      this.OnVwBaseOrtesRead(ref items);

      return items;
    }

    partial void OnVwBaseOrtesRead(ref IQueryable<Models.DbOptimo.VwBaseOrte> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Ort}")]
    public SingleResult<VwBaseOrte> GetVwBaseOrte(string key)
    {
        var items = this.context.VwBaseOrtes.AsNoTracking().Where(i=>i.Ort == key);
        this.OnVwBaseOrtesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwBaseOrtesGet(ref IQueryable<Models.DbOptimo.VwBaseOrte> items);

  }
}
