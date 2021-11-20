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

  [ODataRoutePrefix("odata/dbOptimo/InventurArtikels")]
  [Route("mvc/odata/dbOptimo/InventurArtikels")]
  public partial class InventurArtikelsController : ODataController
  {
    private Data.DbOptimoContext context;

    public InventurArtikelsController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/InventurArtikels
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.InventurArtikel> GetInventurArtikels()
    {
      var items = this.context.InventurArtikels.AsQueryable<Models.DbOptimo.InventurArtikel>();
      this.OnInventurArtikelsRead(ref items);

      return items;
    }

    partial void OnInventurArtikelsRead(ref IQueryable<Models.DbOptimo.InventurArtikel> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{ArtikelID}")]
    public SingleResult<InventurArtikel> GetInventurArtikel(int key)
    {
        var items = this.context.InventurArtikels.Where(i=>i.ArtikelID == key);
        this.OnInventurArtikelsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnInventurArtikelsGet(ref IQueryable<Models.DbOptimo.InventurArtikel> items);

    partial void OnInventurArtikelDeleted(Models.DbOptimo.InventurArtikel item);

    [HttpDelete("{ArtikelID}")]
    public IActionResult DeleteInventurArtikel(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.InventurArtikels
                .Where(i => i.ArtikelID == key)
                .Include(i => i.InventurErfassungs)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnInventurArtikelDeleted(itemToDelete);
            this.context.InventurArtikels.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnInventurArtikelUpdated(Models.DbOptimo.InventurArtikel item);

    [HttpPut("{ArtikelID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutInventurArtikel(int key, [FromBody]Models.DbOptimo.InventurArtikel newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.ArtikelID != key))
            {
                return BadRequest();
            }

            this.OnInventurArtikelUpdated(newItem);
            this.context.InventurArtikels.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.InventurArtikels.Where(i => i.ArtikelID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "InventurBasis");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{ArtikelID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchInventurArtikel(int key, [FromBody]Delta<Models.DbOptimo.InventurArtikel> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.InventurArtikels.Where(i => i.ArtikelID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnInventurArtikelUpdated(itemToUpdate);
            this.context.InventurArtikels.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.InventurArtikels.Where(i => i.ArtikelID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "InventurBasis");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnInventurArtikelCreated(Models.DbOptimo.InventurArtikel item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbOptimo.InventurArtikel item)
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

            this.OnInventurArtikelCreated(item);
            this.context.InventurArtikels.Add(item);
            this.context.SaveChanges();

            var key = item.ArtikelID;

            var itemToReturn = this.context.InventurArtikels.Where(i => i.ArtikelID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "InventurBasis");

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
