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

  [ODataRoutePrefix("odata/dbOptimo/VwBaseKontaktes")]
  [Route("mvc/odata/dbOptimo/VwBaseKontaktes")]
  public partial class VwBaseKontaktesController : ODataController
  {
    private Data.DbOptimoContext context;

    public VwBaseKontaktesController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/VwBaseKontaktes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.VwBaseKontakte> GetVwBaseKontaktes()
    {
      var items = this.context.VwBaseKontaktes.AsNoTracking().AsQueryable<Models.DbOptimo.VwBaseKontakte>();
      this.OnVwBaseKontaktesRead(ref items);

      return items;
    }

    partial void OnVwBaseKontaktesRead(ref IQueryable<Models.DbOptimo.VwBaseKontakte> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Name1}")]
    public SingleResult<VwBaseKontakte> GetVwBaseKontakte(string key)
    {
        var items = this.context.VwBaseKontaktes.AsNoTracking().Where(i=>i.Name1 == key);
        this.OnVwBaseKontaktesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwBaseKontaktesGet(ref IQueryable<Models.DbOptimo.VwBaseKontakte> items);

  }
}
