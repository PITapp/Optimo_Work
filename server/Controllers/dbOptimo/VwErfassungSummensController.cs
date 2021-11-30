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

  [ODataRoutePrefix("odata/dbOptimo/VwErfassungSummens")]
  [Route("mvc/odata/dbOptimo/VwErfassungSummens")]
  public partial class VwErfassungSummensController : ODataController
  {
    private Data.DbOptimoContext context;

    public VwErfassungSummensController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/VwErfassungSummens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.VwErfassungSummen> GetVwErfassungSummens()
    {
      var items = this.context.VwErfassungSummens.AsNoTracking().AsQueryable<Models.DbOptimo.VwErfassungSummen>();
      this.OnVwErfassungSummensRead(ref items);

      return items;
    }

    partial void OnVwErfassungSummensRead(ref IQueryable<Models.DbOptimo.VwErfassungSummen> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Auftragsnr}")]
    public SingleResult<VwErfassungSummen> GetVwErfassungSummen(string key)
    {
        var items = this.context.VwErfassungSummens.AsNoTracking().Where(i=>i.Auftragsnr == key);
        this.OnVwErfassungSummensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwErfassungSummensGet(ref IQueryable<Models.DbOptimo.VwErfassungSummen> items);

  }
}
