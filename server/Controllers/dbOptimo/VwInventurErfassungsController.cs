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

  [ODataRoutePrefix("odata/dbOptimo/VwInventurErfassungs")]
  [Route("mvc/odata/dbOptimo/VwInventurErfassungs")]
  public partial class VwInventurErfassungsController : ODataController
  {
    private Data.DbOptimoContext context;

    public VwInventurErfassungsController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/VwInventurErfassungs
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.VwInventurErfassung> GetVwInventurErfassungs()
    {
      var items = this.context.VwInventurErfassungs.AsNoTracking().AsQueryable<Models.DbOptimo.VwInventurErfassung>();
      this.OnVwInventurErfassungsRead(ref items);

      return items;
    }

    partial void OnVwInventurErfassungsRead(ref IQueryable<Models.DbOptimo.VwInventurErfassung> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{ArtikelID}")]
    public SingleResult<VwInventurErfassung> GetVwInventurErfassung(int key)
    {
        var items = this.context.VwInventurErfassungs.AsNoTracking().Where(i=>i.ArtikelID == key);
        this.OnVwInventurErfassungsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwInventurErfassungsGet(ref IQueryable<Models.DbOptimo.VwInventurErfassung> items);

  }
}
