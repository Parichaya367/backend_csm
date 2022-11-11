
using Microsoft.AspNetCore.Mvc;
using CSMAPI.Models;

using Microsoft.AspNetCore.Authorization;

namespace CSMAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SubTask5Controller : ControllerBase
{
    private readonly ILogger<SubTask5Controller> _logger;

    public SubTask5Controller(ILogger<SubTask5Controller> logger)
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
            var subTasks = from a in db.SubTask5 select a;
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

            var subTask = db.SubTask5.Find(id);
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
    public IActionResult Post([FromBody] DTOs.SubTask5 data)
    {
        try {
            var db = new CSMDbContext();
            var subTask = new SubTask5();
            string dateString = DateTime.Now.ToString("yyyyMM");
            var someEntity = db.Tempcsmno.Find(dateString);
            if (someEntity == null) return NotFound();
            string csmproblemformat = String.Format("CSM-"+dateString+"{0:00000}",someEntity.count);
            string subtaskformat = String.Format(csmproblemformat+"-005");
            subTask.SubtaskId = subtaskformat;
            subTask.Pbcode = data.Pbcode;
            subTask.Description = data.Description;
            subTask.Status = data.Status;

            db.SubTask5.Add(subTask);
            db.SaveChanges();

            return Ok();

        } catch (Exception e) {
            return Ok(new { mesg=e.ToString()});
        }
    }

    [Route("{id}")]
    [HttpPut]
    //[Authorize(Roles = "subtask")]
    public IActionResult Put( [FromBody] DTOs.SubTask5 data, string id)
    {
        try {
            var db = new CSMDbContext();

            var subTask = db.SubTask5.Find(id);
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
        var subTask = db.SubTask5.Find(id);
        if (subTask == null){
            return NotFound();
        }
        try {
            db.SubTask5.Remove(subTask);
            db.SaveChanges();
        } catch (Exception ex) {
            return Ok(new { mesg=ex.ToString()});
        }
        return Ok();

    }
}