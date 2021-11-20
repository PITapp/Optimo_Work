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

  [ODataRoutePrefix("odata/dbOptimo/InventurBasisStatuses")]
  [Route("mvc/odata/dbOptimo/InventurBasisStatuses")]
  public partial class InventurBasisStatusesController : ODataController
  {
    private Data.DbOptimoContext context;

    public InventurBasisStatusesController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/InventurBasisStatuses
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.InventurBasisStatus> GetInventurBasisStatuses()
    {
      var items = this.context.InventurBasisStatuses.AsQueryable<Models.DbOptimo.InventurBasisStatus>();
      this.OnInventurBasisStatusesRead(ref items);

      return items;
    }

    partial void OnInventurBasisStatusesRead(ref IQueryable<Models.DbOptimo.InventurBasisStatus> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{InventurBasisStatusID}")]
    public SingleResult<InventurBasisStatus> GetInventurBasisStatus(int key)
    {
        var items = this.context.InventurBasisStatuses.Where(i=>i.InventurBasisStatusID == key);
        this.OnInventurBasisStatusesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnInventurBasisStatusesGet(ref IQueryable<Models.DbOptimo.InventurBasisStatus> items);

    partial void OnInventurBasisStatusDeleted(Models.DbOptimo.InventurBasisStatus item);

    [HttpDelete("{InventurBasisStatusID}")]
    public IActionResult DeleteInventurBasisStatus(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.InventurBasisStatuses
                .Where(i => i.InventurBasisStatusID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnInventurBasisStatusDeleted(itemToDelete);
            this.context.InventurBasisStatuses.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnInventurBasisStatusUpdated(Models.DbOptimo.InventurBasisStatus item);

    [HttpPut("{InventurBasisStatusID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutInventurBasisStatus(int key, [FromBody]Models.DbOptimo.InventurBasisStatus newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.InventurBasisStatusID != key))
            {
                return BadRequest();
            }

            this.OnInventurBasisStatusUpdated(newItem);
            this.context.InventurBasisStatuses.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.InventurBasisStatuses.Where(i => i.InventurBasisStatusID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{InventurBasisStatusID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchInventurBasisStatus(int key, [FromBody]Delta<Models.DbOptimo.InventurBasisStatus> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.InventurBasisStatuses.Where(i => i.InventurBasisStatusID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnInventurBasisStatusUpdated(itemToUpdate);
            this.context.InventurBasisStatuses.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.InventurBasisStatuses.Where(i => i.InventurBasisStatusID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnInventurBasisStatusCreated(Models.DbOptimo.InventurBasisStatus item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbOptimo.InventurBasisStatus item)
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

            this.OnInventurBasisStatusCreated(item);
            this.context.InventurBasisStatuses.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbOptimo/InventurBasisStatuses/{item.InventurBasisStatusID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
