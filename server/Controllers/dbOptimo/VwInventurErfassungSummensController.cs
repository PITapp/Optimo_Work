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

  [ODataRoutePrefix("odata/dbOptimo/VwInventurErfassungSummens")]
  [Route("mvc/odata/dbOptimo/VwInventurErfassungSummens")]
  public partial class VwInventurErfassungSummensController : ODataController
  {
    private Data.DbOptimoContext context;

    public VwInventurErfassungSummensController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/VwInventurErfassungSummens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.VwInventurErfassungSummen> GetVwInventurErfassungSummens()
    {
      var items = this.context.VwInventurErfassungSummens.AsNoTracking().AsQueryable<Models.DbOptimo.VwInventurErfassungSummen>();
      this.OnVwInventurErfassungSummensRead(ref items);

      return items;
    }

    partial void OnVwInventurErfassungSummensRead(ref IQueryable<Models.DbOptimo.VwInventurErfassungSummen> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{ArtikelID}")]
    public SingleResult<VwInventurErfassungSummen> GetVwInventurErfassungSummen(int key)
    {
        var items = this.context.VwInventurErfassungSummens.AsNoTracking().Where(i=>i.ArtikelID == key);
        this.OnVwInventurErfassungSummensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwInventurErfassungSummensGet(ref IQueryable<Models.DbOptimo.VwInventurErfassungSummen> items);

  }
}
