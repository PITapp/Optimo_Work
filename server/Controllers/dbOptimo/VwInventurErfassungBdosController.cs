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

  [ODataRoutePrefix("odata/dbOptimo/VwInventurErfassungBdos")]
  [Route("mvc/odata/dbOptimo/VwInventurErfassungBdos")]
  public partial class VwInventurErfassungBdosController : ODataController
  {
    private Data.DbOptimoContext context;

    public VwInventurErfassungBdosController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/VwInventurErfassungBdos
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.VwInventurErfassungBdo> GetVwInventurErfassungBdos()
    {
      var items = this.context.VwInventurErfassungBdos.AsNoTracking().AsQueryable<Models.DbOptimo.VwInventurErfassungBdo>();
      this.OnVwInventurErfassungBdosRead(ref items);

      return items;
    }

    partial void OnVwInventurErfassungBdosRead(ref IQueryable<Models.DbOptimo.VwInventurErfassungBdo> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Artikelnummer}")]
    public SingleResult<VwInventurErfassungBdo> GetVwInventurErfassungBdo(string key)
    {
        var items = this.context.VwInventurErfassungBdos.AsNoTracking().Where(i=>i.Artikelnummer == key);
        this.OnVwInventurErfassungBdosGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwInventurErfassungBdosGet(ref IQueryable<Models.DbOptimo.VwInventurErfassungBdo> items);

  }
}
