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

  [ODataRoutePrefix("odata/dbOptimo/VwBenutzerRollens")]
  [Route("mvc/odata/dbOptimo/VwBenutzerRollens")]
  public partial class VwBenutzerRollensController : ODataController
  {
    private Data.DbOptimoContext context;

    public VwBenutzerRollensController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/VwBenutzerRollens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.VwBenutzerRollen> GetVwBenutzerRollens()
    {
      var items = this.context.VwBenutzerRollens.AsNoTracking().AsQueryable<Models.DbOptimo.VwBenutzerRollen>();
      this.OnVwBenutzerRollensRead(ref items);

      return items;
    }

    partial void OnVwBenutzerRollensRead(ref IQueryable<Models.DbOptimo.VwBenutzerRollen> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{AspNetUsers_Id}")]
    public SingleResult<VwBenutzerRollen> GetVwBenutzerRollen(string key)
    {
        var items = this.context.VwBenutzerRollens.AsNoTracking().Where(i=>i.AspNetUsers_Id == key);
        this.OnVwBenutzerRollensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwBenutzerRollensGet(ref IQueryable<Models.DbOptimo.VwBenutzerRollen> items);

  }
}
