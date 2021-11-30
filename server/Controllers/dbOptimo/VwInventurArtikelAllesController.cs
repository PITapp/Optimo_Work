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

  [ODataRoutePrefix("odata/dbOptimo/VwInventurArtikelAlles")]
  [Route("mvc/odata/dbOptimo/VwInventurArtikelAlles")]
  public partial class VwInventurArtikelAllesController : ODataController
  {
    private Data.DbOptimoContext context;

    public VwInventurArtikelAllesController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/VwInventurArtikelAlles
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.VwInventurArtikelAlle> GetVwInventurArtikelAlles()
    {
      var items = this.context.VwInventurArtikelAlles.AsNoTracking().AsQueryable<Models.DbOptimo.VwInventurArtikelAlle>();
      this.OnVwInventurArtikelAllesRead(ref items);

      return items;
    }

    partial void OnVwInventurArtikelAllesRead(ref IQueryable<Models.DbOptimo.VwInventurArtikelAlle> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{InventurID}")]
    public SingleResult<VwInventurArtikelAlle> GetVwInventurArtikelAlle(int key)
    {
        var items = this.context.VwInventurArtikelAlles.AsNoTracking().Where(i=>i.InventurID == key);
        this.OnVwInventurArtikelAllesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwInventurArtikelAllesGet(ref IQueryable<Models.DbOptimo.VwInventurArtikelAlle> items);

  }
}
