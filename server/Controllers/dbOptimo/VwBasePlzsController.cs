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

  [ODataRoutePrefix("odata/dbOptimo/VwBasePlzs")]
  [Route("mvc/odata/dbOptimo/VwBasePlzs")]
  public partial class VwBasePlzsController : ODataController
  {
    private Data.DbOptimoContext context;

    public VwBasePlzsController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/VwBasePlzs
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.VwBasePlz> GetVwBasePlzs()
    {
      var items = this.context.VwBasePlzs.AsNoTracking().AsQueryable<Models.DbOptimo.VwBasePlz>();
      this.OnVwBasePlzsRead(ref items);

      return items;
    }

    partial void OnVwBasePlzsRead(ref IQueryable<Models.DbOptimo.VwBasePlz> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{PLZ}")]
    public SingleResult<VwBasePlz> GetVwBasePlz(string key)
    {
        var items = this.context.VwBasePlzs.AsNoTracking().Where(i=>i.PLZ == key);
        this.OnVwBasePlzsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwBasePlzsGet(ref IQueryable<Models.DbOptimo.VwBasePlz> items);

  }
}
