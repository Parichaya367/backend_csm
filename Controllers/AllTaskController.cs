using Microsoft.AspNetCore.Mvc;
using CSMAPI.Models;

namespace CSMAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AllTaskController : ControllerBase
{
    private readonly ILogger<AllTaskController> _logger;

    public AllTaskController(ILogger<AllTaskController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var db = new CSMDbContext();
            var allTasks = from a in db.AllTask select a;
            return Ok(allTasks);
        }
        catch (Exception e)
        {
            return Ok(new { mesg=e.ToString()});
        }
    }

    [Route("{id}")]
    [HttpGet]
    public IActionResult Get(string id)
    {
        try
        {
            var db = new CSMDbContext();

            var allTask = db.AllTask.Find(id);
            if (allTask == null) return NotFound();

            return Ok(allTask);
        }
        catch (Exception e)
        {
            return Ok(new { mesg=e.ToString()});
        }
    }

    [HttpPost]
    public IActionResult Post()
    {
        try {
            var db = new CSMDbContext();

            var allTask = new AllTask();
            string dateString = DateTime.Now.ToString("yyyyMM");
            var someEntity = db.Tempcsmno.Find(dateString);
            if (someEntity == null) return NotFound();
            string csmproblemformat = String.Format("CSM-"+dateString+"{0:00000}",someEntity.count);
            string alltaskformat = String.Format(csmproblemformat+"-sub");
            allTask.AlltaskId = alltaskformat;
            string temp1 = String.Format(csmproblemformat+"-001");
            string temp2 = String.Format(csmproblemformat+"-002");
            string temp3 = String.Format(csmproblemformat+"-003");
            string temp4 = String.Format(csmproblemformat+"-004");
            string temp5 = String.Format(csmproblemformat+"-005");
            if (db.SubTask1.Find(temp1) != null){
                allTask.FromSubtask1Id = temp1;
            } else {
                allTask.FromSubtask1Id = null;
            }
            if (db.SubTask2.Find(temp2) != null){
                allTask.FromSubtask2Id = temp2;
            } else {
                allTask.FromSubtask2Id = null;
            }if (db.SubTask3.Find(temp3) != null){
                allTask.FromSubtask3Id = temp3;
            } else {
                allTask.FromSubtask3Id = null;
            }
            if (db.SubTask4.Find(temp4) != null){
                allTask.FromSubtask4Id = temp4;
            } else {
                allTask.FromSubtask4Id = null;
            }
            if (db.SubTask5.Find(temp5) != null){
                allTask.FromSubtask5Id = temp5;
            } else {
                allTask.FromSubtask5Id = null;
            }

            db.AllTask.Add(allTask);
            db.SaveChanges();

            return Ok();

        } catch (Exception e) {
            return Ok(new { mesg=e.ToString()});
        }
    }

    [Route("{id}")]
    [HttpPut]
    public IActionResult Put( [FromBody] DTOs.AllTask data, string id)
    {
        try {
            var db = new CSMDbContext();

            var allTask = db.AllTask.Find(id);
            if (allTask == null) return NotFound();
            allTask.FromSubtask1Id = data.FromSubtaskId1;
            allTask.FromSubtask2Id = data.FromSubtaskId2;
            allTask.FromSubtask3Id = data.FromSubtaskId3;
            allTask.FromSubtask4Id = data.FromSubtaskId4;
            allTask.FromSubtask5Id = data.FromSubtaskId5;

            db.SaveChanges();

            return Ok();
        } catch (Exception e) {
            return Ok(new { mesg=e.ToString()});
        }
    }

    [Route("{id}")]
    [HttpDelete]
    public IActionResult Delete(string id)
    {

        var db = new CSMDbContext();
        var allTask = db.AllTask.Find(id);
        if (allTask == null){
            return NotFound();
        }
        try {
            db.AllTask.Remove(allTask);
            db.SaveChanges();
        } catch (Exception ex) {
            return Ok(new { mesg=ex.ToString()});
        }
        return Ok();
    }
}