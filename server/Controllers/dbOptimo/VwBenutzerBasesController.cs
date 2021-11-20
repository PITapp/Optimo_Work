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

  [ODataRoutePrefix("odata/dbOptimo/VwBenutzerBases")]
  [Route("mvc/odata/dbOptimo/VwBenutzerBases")]
  public partial class VwBenutzerBasesController : ODataController
  {
    private Data.DbOptimoContext context;

    public VwBenutzerBasesController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/VwBenutzerBases
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.VwBenutzerBase> GetVwBenutzerBases()
    {
      var items = this.context.VwBenutzerBases.AsNoTracking().AsQueryable<Models.DbOptimo.VwBenutzerBase>();
      this.OnVwBenutzerBasesRead(ref items);

      return items;
    }

    partial void OnVwBenutzerBasesRead(ref IQueryable<Models.DbOptimo.VwBenutzerBase> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{AspNetUsers_Id}")]
    public SingleResult<VwBenutzerBase> GetVwBenutzerBase(string key)
    {
        var items = this.context.VwBenutzerBases.AsNoTracking().Where(i=>i.AspNetUsers_Id == key);
        this.OnVwBenutzerBasesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwBenutzerBasesGet(ref IQueryable<Models.DbOptimo.VwBenutzerBase> items);

  }
}
