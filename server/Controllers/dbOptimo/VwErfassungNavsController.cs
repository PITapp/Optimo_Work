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

  [ODataRoutePrefix("odata/dbOptimo/VwErfassungNavs")]
  [Route("mvc/odata/dbOptimo/VwErfassungNavs")]
  public partial class VwErfassungNavsController : ODataController
  {
    private Data.DbOptimoContext context;

    public VwErfassungNavsController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/VwErfassungNavs
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.VwErfassungNav> GetVwErfassungNavs()
    {
      var items = this.context.VwErfassungNavs.AsNoTracking().AsQueryable<Models.DbOptimo.VwErfassungNav>();
      this.OnVwErfassungNavsRead(ref items);

      return items;
    }

    partial void OnVwErfassungNavsRead(ref IQueryable<Models.DbOptimo.VwErfassungNav> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Auftragsnr}")]
    public SingleResult<VwErfassungNav> GetVwErfassungNav(string key)
    {
        var items = this.context.VwErfassungNavs.AsNoTracking().Where(i=>i.Auftragsnr == key);
        this.OnVwErfassungNavsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwErfassungNavsGet(ref IQueryable<Models.DbOptimo.VwErfassungNav> items);

  }
}
