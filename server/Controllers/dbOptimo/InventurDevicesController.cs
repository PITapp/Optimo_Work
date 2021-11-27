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

  [ODataRoutePrefix("odata/dbOptimo/InventurDevices")]
  [Route("mvc/odata/dbOptimo/InventurDevices")]
  public partial class InventurDevicesController : ODataController
  {
    private Data.DbOptimoContext context;

    public InventurDevicesController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/InventurDevices
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.InventurDevice> GetInventurDevices()
    {
      var items = this.context.InventurDevices.AsQueryable<Models.DbOptimo.InventurDevice>();
      this.OnInventurDevicesRead(ref items);

      return items;
    }

    partial void OnInventurDevicesRead(ref IQueryable<Models.DbOptimo.InventurDevice> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{DeviceID}")]
    public SingleResult<InventurDevice> GetInventurDevice(int key)
    {
        var items = this.context.InventurDevices.Where(i=>i.DeviceID == key);
        this.OnInventurDevicesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnInventurDevicesGet(ref IQueryable<Models.DbOptimo.InventurDevice> items);

    partial void OnInventurDeviceDeleted(Models.DbOptimo.InventurDevice item);

    [HttpDelete("{DeviceID}")]
    public IActionResult DeleteInventurDevice(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.InventurDevices
                .Where(i => i.DeviceID == key)
                .Include(i => i.InventurErfassungs)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnInventurDeviceDeleted(itemToDelete);
            this.context.InventurDevices.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnInventurDeviceUpdated(Models.DbOptimo.InventurDevice item);

    [HttpPut("{DeviceID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutInventurDevice(int key, [FromBody]Models.DbOptimo.InventurDevice newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.DeviceID != key))
            {
                return BadRequest();
            }

            this.OnInventurDeviceUpdated(newItem);
            this.context.InventurDevices.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.InventurDevices.Where(i => i.DeviceID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "InventurBasis");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{DeviceID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchInventurDevice(int key, [FromBody]Delta<Models.DbOptimo.InventurDevice> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.InventurDevices.Where(i => i.DeviceID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnInventurDeviceUpdated(itemToUpdate);
            this.context.InventurDevices.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.InventurDevices.Where(i => i.DeviceID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "InventurBasis");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnInventurDeviceCreated(Models.DbOptimo.InventurDevice item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbOptimo.InventurDevice item)
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

            this.OnInventurDeviceCreated(item);
            this.context.InventurDevices.Add(item);
            this.context.SaveChanges();

            var key = item.DeviceID;

            var itemToReturn = this.context.InventurDevices.Where(i => i.DeviceID == key);

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
