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

  [ODataRoutePrefix("odata/dbOptimo/BaseKontaktes")]
  [Route("mvc/odata/dbOptimo/BaseKontaktes")]
  public partial class BaseKontaktesController : ODataController
  {
    private Data.DbOptimoContext context;

    public BaseKontaktesController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/BaseKontaktes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.BaseKontakte> GetBaseKontaktes()
    {
      var items = this.context.BaseKontaktes.AsQueryable<Models.DbOptimo.BaseKontakte>();
      this.OnBaseKontaktesRead(ref items);

      return items;
    }

    partial void OnBaseKontaktesRead(ref IQueryable<Models.DbOptimo.BaseKontakte> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{KontaktID}")]
    public SingleResult<BaseKontakte> GetBaseKontakte(int key)
    {
        var items = this.context.BaseKontaktes.Where(i=>i.KontaktID == key);
        this.OnBaseKontaktesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnBaseKontaktesGet(ref IQueryable<Models.DbOptimo.BaseKontakte> items);

    partial void OnBaseKontakteDeleted(Models.DbOptimo.BaseKontakte item);

    [HttpDelete("{KontaktID}")]
    public IActionResult DeleteBaseKontakte(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.BaseKontaktes
                .Where(i => i.KontaktID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnBaseKontakteDeleted(itemToDelete);
            this.context.BaseKontaktes.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBaseKontakteUpdated(Models.DbOptimo.BaseKontakte item);

    [HttpPut("{KontaktID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutBaseKontakte(int key, [FromBody]Models.DbOptimo.BaseKontakte newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KontaktID != key))
            {
                return BadRequest();
            }

            this.OnBaseKontakteUpdated(newItem);
            this.context.BaseKontaktes.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.BaseKontaktes.Where(i => i.KontaktID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{KontaktID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchBaseKontakte(int key, [FromBody]Delta<Models.DbOptimo.BaseKontakte> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.BaseKontaktes.Where(i => i.KontaktID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnBaseKontakteUpdated(itemToUpdate);
            this.context.BaseKontaktes.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.BaseKontaktes.Where(i => i.KontaktID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBaseKontakteCreated(Models.DbOptimo.BaseKontakte item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbOptimo.BaseKontakte item)
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

            this.OnBaseKontakteCreated(item);
            this.context.BaseKontaktes.Add(item);
            this.context.SaveChanges();

            var key = item.KontaktID;

            var itemToReturn = this.context.BaseKontaktes.Where(i => i.KontaktID == key);

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
