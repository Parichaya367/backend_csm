using Microsoft.AspNetCore.Mvc;
using CSMAPI.Models;

using Microsoft.AspNetCore.Authorization;

namespace CSMAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProblemDataController : ControllerBase
{
    private readonly ILogger<ProblemDataController> _logger;

    public ProblemDataController(ILogger<ProblemDataController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    //[Authorize(Roles = "problemdata")]
    public IActionResult Get()
    {
        try
        {
            var db = new CSMDbContext();
            var problemDatas = from a in db.ProblemData select new {a.PdId, a.PdDesc, a.PtId};
            return Ok(problemDatas);

        }
        catch (Exception e)
        {
            return Ok(new { mesg=e.ToString()});
        }
    }

    [Route("{id}")]
    [HttpGet]
    //[Authorize(Roles = "problemdata")]
    public IActionResult Get(string id)
    {
        try
        {
            var db = new CSMDbContext();

            var problemData = db.ProblemData.Find(id);
            if (problemData == null) return NotFound();
            return Ok(problemData);
        }
        catch (Exception e)
        {
            return Ok(new { mesg=e.ToString()});
        }
    }

    [HttpPost]
    //[Authorize(Roles = "problemData")]
    public IActionResult Post([FromBody] DTOs.ProblemData data)
    {
        try {
            var db = new CSMDbContext();

            var problemData = new ProblemData();
            problemData.PdId = data.PdId;
            problemData.PdDesc = data.PdDesc;
            problemData.PtId = data.PtId;

            db.ProblemData.Add(problemData);
            db.SaveChanges();

            return Ok();

        } catch (Exception e) {
            return Ok(new { mesg=e.ToString()});
        }
    }


    [HttpPut]
    //[Authorize(Roles = "subtask3")]
    public IActionResult Put( [FromBody] DTOs.ProblemData data)
    {
        try {
            var db = new CSMDbContext();

            var problemData = db.ProblemData.Find(data.PdId);
            if (problemData == null) return NotFound();
            problemData.PdId = data.PdId;
            problemData.PdDesc = data.PdDesc;
            problemData.PtId = data.PtId;
            db.SaveChanges();

            return Ok();
        } catch (Exception e) {
            return Ok(new { mesg=e.ToString()});
        }
    }

    [Route("{id}")]
    [HttpDelete]
    //[Authorize(Roles = "problemData")]
    public IActionResult Delete(string id)
    {

        var db = new CSMDbContext();
        var problemData = db.ProblemData.Find(id);
        if (problemData == null){
            return NotFound();
        }
        try {
            db.ProblemData.Remove(problemData);
            db.SaveChanges();
        } catch (Exception ex) {
            return Ok(new { mesg=ex.ToString()});
        }
        return Ok();
    }
}