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

  [ODataRoutePrefix("odata/dbOptimo/BaseAnredens")]
  [Route("mvc/odata/dbOptimo/BaseAnredens")]
  public partial class BaseAnredensController : ODataController
  {
    private Data.DbOptimoContext context;

    public BaseAnredensController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/BaseAnredens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.BaseAnreden> GetBaseAnredens()
    {
      var items = this.context.BaseAnredens.AsQueryable<Models.DbOptimo.BaseAnreden>();
      this.OnBaseAnredensRead(ref items);

      return items;
    }

    partial void OnBaseAnredensRead(ref IQueryable<Models.DbOptimo.BaseAnreden> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{AnredeID}")]
    public SingleResult<BaseAnreden> GetBaseAnreden(int key)
    {
        var items = this.context.BaseAnredens.Where(i=>i.AnredeID == key);
        this.OnBaseAnredensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnBaseAnredensGet(ref IQueryable<Models.DbOptimo.BaseAnreden> items);

    partial void OnBaseAnredenDeleted(Models.DbOptimo.BaseAnreden item);

    [HttpDelete("{AnredeID}")]
    public IActionResult DeleteBaseAnreden(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.BaseAnredens
                .Where(i => i.AnredeID == key)
                .Include(i => i.Bases)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnBaseAnredenDeleted(itemToDelete);
            this.context.BaseAnredens.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBaseAnredenUpdated(Models.DbOptimo.BaseAnreden item);

    [HttpPut("{AnredeID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutBaseAnreden(int key, [FromBody]Models.DbOptimo.BaseAnreden newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.AnredeID != key))
            {
                return BadRequest();
            }

            this.OnBaseAnredenUpdated(newItem);
            this.context.BaseAnredens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.BaseAnredens.Where(i => i.AnredeID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{AnredeID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchBaseAnreden(int key, [FromBody]Delta<Models.DbOptimo.BaseAnreden> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.BaseAnredens.Where(i => i.AnredeID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnBaseAnredenUpdated(itemToUpdate);
            this.context.BaseAnredens.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.BaseAnredens.Where(i => i.AnredeID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBaseAnredenCreated(Models.DbOptimo.BaseAnreden item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbOptimo.BaseAnreden item)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (item == null)
            {
                return BadRequest();
            }

            this.OnBaseAnredenCreated(item);
            this.context.BaseAnredens.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbOptimo/BaseAnredens/{item.AnredeID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
