using Microsoft.AspNetCore.Mvc;
using CSMAPI.Models;

using Microsoft.AspNetCore.Authorization;

namespace CSMAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly ILogger<ProjectsController> _logger;

    public ProjectsController(ILogger<ProjectsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    //[Authorize(Roles = "project")]
    public IActionResult Get()
    {
        try {
            var db = new CSMDbContext();
            var projects = from a in db.Project select a;
            return Ok(projects);

        } catch (Exception e){
            return Ok(new { mesg=e.ToString()});
        }
    }

    [Route("{id}")]
    [HttpGet]
    //[Authorize(Roles = "user")]
    public IActionResult Get(string id)
    {
        try {
            var db = new CSMDbContext();

            var project = db.Project.Find(id);
            if (project == null) return NotFound();

            return Ok(project);
        } catch (Exception e) {
            return Ok(new { mesg=e.ToString()});
        }
    }
    
    [HttpPost]
    //[Authorize(Roles = "project")]
    public IActionResult Post([FromBody] DTOs.Project data)
    {
        try {
            var db = new CSMDbContext();

            var project = new Project();
            project.ProjId = data.ProjId;
            project.ProjName = data.ProjName;

            db.Project.Add(project);
            db.SaveChanges();

            return Ok();

        } catch (Exception e) {
            return Ok(new { mesg=e.ToString()});
        }
    }

    
    [HttpPut]
    //[Authorize(Roles = "project")]
    public IActionResult Put( [FromBody] DTOs.Project data)
    {
        try {
            var db = new CSMDbContext();

            var project = db.Project.Find(data.ProjId);
            if (project == null) return NotFound();
            project.ProjName = data.ProjName;

            db.SaveChanges();

            return Ok();
        } catch (Exception e) {
            return Ok(new { mesg=e.ToString()});
        }
    }

    [Route("{id}")]
    [HttpDelete]
    //[Authorize(Roles = "project")]
    public IActionResult Delete(string id)
    {
        var db = new CSMDbContext();
        var project = db.Project.Find(id);
        if (project == null){
            return NotFound();
        }
        try {
            db.Project.Remove(project);
            db.SaveChanges();
        } catch (Exception ex) {
            return Ok(new { mesg=ex.ToString()});
        }
        return Ok();
    }
}