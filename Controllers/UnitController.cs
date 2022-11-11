using Microsoft.AspNetCore.Mvc;
using CSMAPI.Models;

using Microsoft.AspNetCore.Authorization;

namespace CSMAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UnitController : ControllerBase
{
    private readonly ILogger<UnitController> _logger;

    public UnitController(ILogger<UnitController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    //[Authorize(Roles = "unit")]
    public IActionResult Get()
    {
        try
        {
            var db = new CSMDbContext();
            var units = from a in db.Unit select a;
            return Ok(units);

        }
        catch (Exception e)
        {
            return Ok(new { mesg=e.ToString()});
        }
    }

    [Route("{id}")]
    [HttpGet]
    //[Authorize(Roles = "unit")]
    public IActionResult Get(string id)
    {
        try
        {
            var db = new CSMDbContext();

            var unit = db.Unit.Find(id);
            if (unit == null) return NotFound();

            return Ok(unit);
        }
        catch (Exception e)
        {
            return Ok(new { mesg=e.ToString()});
        }
    }

    [HttpPost]
    //[Authorize(Roles = "unit")]
    public IActionResult Post([FromBody] DTOs.Unit data)
    {
        try {
            var db = new CSMDbContext();

            var unit = new Unit();
            unit.UnitId = data.UnitId;
            unit.BelongToProj = data.BelongToProj;
            unit.BelongToUser = data.BelongToUser;
            unit.Address = data.Address;

            // unit.BelongToProjNavigation.ProjId = data.BelongToProjNavigation.ProjId;
            // unit.BelongToUserNavigation.UserId = data.BelongToUserNavigation.UserId;

            db.Unit.Add(unit);
            db.SaveChanges();

            return Ok();

        } catch (Exception e) {
            return Ok(new { mesg=e.ToString()});
        }
    }


    [HttpPut]
    //[Authorize(Roles = "unit")]
    public IActionResult Put( [FromBody] DTOs.Unit data)
    {
        try {
            var db = new CSMDbContext();

            var unit = db.Unit.Find(data.UnitId);
            if (unit == null) return NotFound();
            unit.BelongToProj = data.BelongToProj;
            unit.BelongToUser = data.BelongToUser;
            unit.Address = data.Address;

            db.SaveChanges();

            return Ok();

        } catch (Exception e) {
            return Ok(new { mesg=e.ToString()});
        }
    }

    [Route("{id}")]
    [HttpDelete]
    //[Authorize(Roles = "unit")]
    public IActionResult Delete(string id)
    {
        var db = new CSMDbContext();
        var unit = db.Unit.Find(id);
        if (unit == null){
            return NotFound();
        }
        try {
            db.Unit.Remove(unit);
            db.SaveChanges();
        } catch (Exception ex) {
            return Ok(new { mesg=ex.ToString()});
        }
        return Ok();

    }
}