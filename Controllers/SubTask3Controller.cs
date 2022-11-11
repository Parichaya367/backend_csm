using Microsoft.AspNetCore.Mvc;
using CSMAPI.Models;

using Microsoft.AspNetCore.Authorization;

namespace CSMAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SubTask3Controller : ControllerBase
{
    private readonly ILogger<SubTask3Controller> _logger;

    public SubTask3Controller(ILogger<SubTask3Controller> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    //[Authorize(Roles = "subtask")]
    public IActionResult Get()
    {
        try
        {
            var db = new CSMDbContext();
            var subTasks = from a in db.SubTask3 select a;
            return Ok(subTasks);

        }
        catch (Exception e)
        {
            return Ok(new { mesg=e.ToString()});
        }
    }

    [Route("{id}")]
    [HttpGet]
    //[Authorize(Roles = "subtask1")]
    public IActionResult Get(string id)
    {
        try
        {
            var db = new CSMDbContext();

            var subTask = db.SubTask3.Find(id);
            if (subTask == null) return NotFound();

            return Ok(subTask);
        }
        catch (Exception e)
        {
            return Ok(new { mesg=e.ToString()});
        }
    }

    [HttpPost]
    //[Authorize(Roles = "subtask")]
    public IActionResult Post([FromBody] DTOs.SubTask3 data)
    {
        try {
            var db = new CSMDbContext();
            var subTask = new SubTask3();
            string dateString = DateTime.Now.ToString("yyyyMM");
            var someEntity = db.Tempcsmno.Find(dateString);
            if (someEntity == null) return NotFound();
            string csmproblemformat = String.Format("CSM-"+dateString+"{0:00000}",someEntity.count);
            string subtaskformat = String.Format(csmproblemformat+"-003");
            subTask.SubtaskId = subtaskformat;
            subTask.Pbcode = data.Pbcode;
            subTask.Description = data.Description;
            subTask.Status = data.Status;

            db.SubTask3.Add(subTask);
            db.SaveChanges();

            return Ok();

        } catch (Exception e) {
            return Ok(new { mesg=e.ToString()});
        }
    }

    [Route("{id}")]
    [HttpPut]
    //[Authorize(Roles = "subtask")]
    public IActionResult Put( [FromBody] DTOs.SubTask3 data, string id)
    {
        try {
            var db = new CSMDbContext();

            var subTask = db.SubTask3.Find(id);
            if (subTask == null) return NotFound();
            subTask.Pbcode = data.Pbcode;
            subTask.Description = data.Description;
            subTask.Status = data.Status;

            db.SaveChanges();

            return Ok();
        } catch (Exception e) {
            return Ok(new { mesg=e.ToString()});
        }
    }

    [Route("{id}")]
    [HttpDelete]
    //[Authorize(Roles = "subtask")]
    public IActionResult Delete(string id)
    {

        var db = new CSMDbContext();
        var subTask = db.SubTask3.Find(id);
        if (subTask == null){
            return NotFound();
        }
        try {
            db.SubTask3.Remove(subTask);
            db.SaveChanges();
        } catch (Exception ex) {
            return Ok(new { mesg=ex.ToString()});
        }
        return Ok();

    }
}