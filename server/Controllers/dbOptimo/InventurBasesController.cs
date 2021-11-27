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

  [ODataRoutePrefix("odata/dbOptimo/InventurBases")]
  [Route("mvc/odata/dbOptimo/InventurBases")]
  public partial class InventurBasesController : ODataController
  {
    private Data.DbOptimoContext context;

    public InventurBasesController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/InventurBases
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.InventurBasis> GetInventurBases()
    {
      var items = this.context.InventurBases.AsQueryable<Models.DbOptimo.InventurBasis>();
      this.OnInventurBasesRead(ref items);

      return items;
    }

    partial void OnInventurBasesRead(ref IQueryable<Models.DbOptimo.InventurBasis> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{InventurID}")]
    public SingleResult<InventurBasis> GetInventurBasis(int key)
    {
        var items = this.context.InventurBases.Where(i=>i.InventurID == key);
        this.OnInventurBasesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnInventurBasesGet(ref IQueryable<Models.DbOptimo.InventurBasis> items);

    partial void OnInventurBasisDeleted(Models.DbOptimo.InventurBasis item);

    [HttpDelete("{InventurID}")]
    public IActionResult DeleteInventurBasis(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.InventurBases
                .Where(i => i.InventurID == key)
                .Include(i => i.InventurArtikels)
                .Include(i => i.InventurDevices)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnInventurBasisDeleted(itemToDelete);
            this.context.InventurBases.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnInventurBasisUpdated(Models.DbOptimo.InventurBasis item);

    [HttpPut("{InventurID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutInventurBasis(int key, [FromBody]Models.DbOptimo.InventurBasis newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.InventurID != key))
            {
                return BadRequest();
            }

            this.OnInventurBasisUpdated(newItem);
            this.context.InventurBases.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.InventurBases.Where(i => i.InventurID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "InventurBasisStatus");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{InventurID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchInventurBasis(int key, [FromBody]Delta<Models.DbOptimo.InventurBasis> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.InventurBases.Where(i => i.InventurID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnInventurBasisUpdated(itemToUpdate);
            this.context.InventurBases.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.InventurBases.Where(i => i.InventurID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "InventurBasisStatus");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnInventurBasisCreated(Models.DbOptimo.InventurBasis item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbOptimo.InventurBasis item)
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

            this.OnInventurBasisCreated(item);
            this.context.InventurBases.Add(item);
            this.context.SaveChanges();

            var key = item.InventurID;

            var itemToReturn = this.context.InventurBases.Where(i => i.InventurID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "InventurBasisStatus");

            return new ObjectResult(SingleResult.Create(itemToReturn))
            {
                StatusCode = 201
            };
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
