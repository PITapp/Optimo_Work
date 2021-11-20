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

  [ODataRoutePrefix("odata/dbOptimo/Benutzers")]
  [Route("mvc/odata/dbOptimo/Benutzers")]
  public partial class BenutzersController : ODataController
  {
    private Data.DbOptimoContext context;

    public BenutzersController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/Benutzers
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.Benutzer> GetBenutzers()
    {
      var items = this.context.Benutzers.AsQueryable<Models.DbOptimo.Benutzer>();
      this.OnBenutzersRead(ref items);

      return items;
    }

    partial void OnBenutzersRead(ref IQueryable<Models.DbOptimo.Benutzer> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BenutzerID}")]
    public SingleResult<Benutzer> GetBenutzer(int key)
    {
        var items = this.context.Benutzers.Where(i=>i.BenutzerID == key);
        this.OnBenutzersGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnBenutzersGet(ref IQueryable<Models.DbOptimo.Benutzer> items);

    partial void OnBenutzerDeleted(Models.DbOptimo.Benutzer item);

    [HttpDelete("{BenutzerID}")]
    public IActionResult DeleteBenutzer(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.Benutzers
                .Where(i => i.BenutzerID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnBenutzerDeleted(itemToDelete);
            this.context.Benutzers.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBenutzerUpdated(Models.DbOptimo.Benutzer item);

    [HttpPut("{BenutzerID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutBenutzer(int key, [FromBody]Models.DbOptimo.Benutzer newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.BenutzerID != key))
            {
                return BadRequest();
            }

            this.OnBenutzerUpdated(newItem);
            this.context.Benutzers.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Benutzers.Where(i => i.BenutzerID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{BenutzerID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchBenutzer(int key, [FromBody]Delta<Models.DbOptimo.Benutzer> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.Benutzers.Where(i => i.BenutzerID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnBenutzerUpdated(itemToUpdate);
            this.context.Benutzers.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.Benutzers.Where(i => i.BenutzerID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBenutzerCreated(Models.DbOptimo.Benutzer item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbOptimo.Benutzer item)
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

            this.OnBenutzerCreated(item);
            this.context.Benutzers.Add(item);
            this.context.SaveChanges();

            var key = item.BenutzerID;

            var itemToReturn = this.context.Benutzers.Where(i => i.BenutzerID == key);

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
