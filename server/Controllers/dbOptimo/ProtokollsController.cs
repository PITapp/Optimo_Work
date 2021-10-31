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

  [ODataRoutePrefix("odata/dbOptimo/Protokolls")]
  [Route("mvc/odata/dbOptimo/Protokolls")]
  public partial class ProtokollsController : ODataController
  {
    private Data.DbOptimoContext context;

    public ProtokollsController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/Protokolls
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.Protokoll> GetProtokolls()
    {
      var items = this.context.Protokolls.AsQueryable<Models.DbOptimo.Protokoll>();
      this.OnProtokollsRead(ref items);

      return items;
    }

    partial void OnProtokollsRead(ref IQueryable<Models.DbOptimo.Protokoll> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{ProtokollID}")]
    public SingleResult<Protokoll> GetProtokoll(int key)
    {
        var items = this.context.Protokolls.Where(i=>i.ProtokollID == key);
        this.OnProtokollsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnProtokollsGet(ref IQueryable<Models.DbOptimo.Protokoll> items);

    partial void OnProtokollDeleted(Models.DbOptimo.Protokoll item);

    [HttpDelete("{ProtokollID}")]
    public IActionResult DeleteProtokoll(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.Protokolls
                .Where(i => i.ProtokollID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnProtokollDeleted(itemToDelete);
            this.context.Protokolls.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnProtokollUpdated(Models.DbOptimo.Protokoll item);

    [HttpPut("{ProtokollID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutProtokoll(int key, [FromBody]Models.DbOptimo.Protokoll newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.ProtokollID != key))
            {
                return BadRequest();
            }

            this.OnProtokollUpdated(newItem);
            this.context.Protokolls.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Protokolls.Where(i => i.ProtokollID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{ProtokollID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchProtokoll(int key, [FromBody]Delta<Models.DbOptimo.Protokoll> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.Protokolls.Where(i => i.ProtokollID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnProtokollUpdated(itemToUpdate);
            this.context.Protokolls.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.Protokolls.Where(i => i.ProtokollID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnProtokollCreated(Models.DbOptimo.Protokoll item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbOptimo.Protokoll item)
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

            this.OnProtokollCreated(item);
            this.context.Protokolls.Add(item);
            this.context.SaveChanges();

            var key = item.ProtokollID;

            var itemToReturn = this.context.Protokolls.Where(i => i.ProtokollID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Base");

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
