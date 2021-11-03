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

  [ODataRoutePrefix("odata/dbOptimo/InventurErfassungs")]
  [Route("mvc/odata/dbOptimo/InventurErfassungs")]
  public partial class InventurErfassungsController : ODataController
  {
    private Data.DbOptimoContext context;

    public InventurErfassungsController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/InventurErfassungs
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.InventurErfassung> GetInventurErfassungs()
    {
      var items = this.context.InventurErfassungs.AsQueryable<Models.DbOptimo.InventurErfassung>();
      this.OnInventurErfassungsRead(ref items);

      return items;
    }

    partial void OnInventurErfassungsRead(ref IQueryable<Models.DbOptimo.InventurErfassung> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{ErfassungID}")]
    public SingleResult<InventurErfassung> GetInventurErfassung(int key)
    {
        var items = this.context.InventurErfassungs.Where(i=>i.ErfassungID == key);
        this.OnInventurErfassungsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnInventurErfassungsGet(ref IQueryable<Models.DbOptimo.InventurErfassung> items);

    partial void OnInventurErfassungDeleted(Models.DbOptimo.InventurErfassung item);

    [HttpDelete("{ErfassungID}")]
    public IActionResult DeleteInventurErfassung(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.InventurErfassungs
                .Where(i => i.ErfassungID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnInventurErfassungDeleted(itemToDelete);
            this.context.InventurErfassungs.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnInventurErfassungUpdated(Models.DbOptimo.InventurErfassung item);

    [HttpPut("{ErfassungID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutInventurErfassung(int key, [FromBody]Models.DbOptimo.InventurErfassung newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.ErfassungID != key))
            {
                return BadRequest();
            }

            this.OnInventurErfassungUpdated(newItem);
            this.context.InventurErfassungs.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.InventurErfassungs.Where(i => i.ErfassungID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Benutzer,InventurArtikel");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{ErfassungID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchInventurErfassung(int key, [FromBody]Delta<Models.DbOptimo.InventurErfassung> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.InventurErfassungs.Where(i => i.ErfassungID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnInventurErfassungUpdated(itemToUpdate);
            this.context.InventurErfassungs.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.InventurErfassungs.Where(i => i.ErfassungID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Benutzer,InventurArtikel");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnInventurErfassungCreated(Models.DbOptimo.InventurErfassung item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbOptimo.InventurErfassung item)
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

            this.OnInventurErfassungCreated(item);
            this.context.InventurErfassungs.Add(item);
            this.context.SaveChanges();

            var key = item.ErfassungID;

            var itemToReturn = this.context.InventurErfassungs.Where(i => i.ErfassungID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Benutzer,InventurArtikel");

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
