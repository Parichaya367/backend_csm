using Microsoft.AspNetCore.Mvc;
using CSMAPI.Models;

using Microsoft.AspNetCore.Authorization;

namespace CSMAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CsmproblemController : ControllerBase
{
    private readonly ILogger<CsmproblemController> _logger;

    public CsmproblemController(ILogger<CsmproblemController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    //[Authorize(Roles = "Csmproblem")]
    public IActionResult Get()
    {
        try
        {
            var db = new CSMDbContext();
            var csmproblems = from a in db.Csmproblem select a;
            return Ok(csmproblems);

        }
        catch (Exception e)
        {
            return Ok(new { mesg=e.ToString()});
        }
    }

    [Route("{id}")]
    [HttpGet]
    //[Authorize(Roles = "Csmproblem")]
    public IActionResult Get(string id)
    {
        try
        {
            var db = new CSMDbContext();

            var csmproblem = db.Csmproblem.Find(id);
            if (csmproblem == null) return NotFound();

            return Ok(csmproblem);
        }
        catch (Exception e)
        {
            return Ok(new { mesg=e.ToString()});
        }
    }

    [HttpPost]
    //[Authorize(Roles = "Csmproblem")]
    public IActionResult Post([FromBody] DTOs.Csmproblem data)
    {
        try {
            var db = new CSMDbContext();
            var csmproblem = new Csmproblem();
            string dateString = DateTime.Now.ToString("yyyyMM");
            var someEntity = db.Tempcsmno.Find(dateString);
            if (someEntity == null) return NotFound();
            string csmproblemformat = String.Format("CSM-"+dateString+"{0:00000}",someEntity.count);
            csmproblem.CsmId = csmproblemformat;
            csmproblem.FromUnitId = data.FromUnitId;
            string temp = String.Format(csmproblemformat+"-sub");
            csmproblem.FromTaskId = temp;
            csmproblem.AvaiDate1 = data.AvaiDate1;
            csmproblem.AvaiDate2 = data.AvaiDate2;
            csmproblem.AvaiDate3 = data.AvaiDate3;
            csmproblem.NameReport = data.NameReport;
            csmproblem.PhoneNum = data.PhoneNum;

            db.Csmproblem.Add(csmproblem);
            db.SaveChanges();
            

            return Ok();

        } catch (Exception e) {
            return Ok(new { mesg=e.ToString()});
        }
    }

    [Route("{id}")]
    [HttpPut]
    //[Authorize(Roles = "Csmproblem")]
    public IActionResult Put( [FromBody] DTOs.Csmproblem data, string id)
    {
        try {
            var db = new CSMDbContext();

            var csmproblem = db.Csmproblem.Find(id);
            if (csmproblem == null) return NotFound();
            csmproblem.FromUnitId = data.FromUnitId;
            csmproblem.AvaiDate1 = data.AvaiDate1;
            csmproblem.AvaiDate2 = data.AvaiDate2;
            csmproblem.AvaiDate3 = data.AvaiDate3;
            csmproblem.NameReport = data.NameReport;
            csmproblem.PhoneNum = data.PhoneNum;

            db.SaveChanges();

            return Ok();
        } catch (Exception e) {
            return Ok(new { mesg=e.ToString()});
        }
    }

    [Route("{id}")]
    [HttpDelete]
    //[Authorize(Roles = "Csmproblem")]
    public IActionResult Delete(string id)
    {

        var db = new CSMDbContext();
        var csmproblem = db.Csmproblem.Find(id);
        if (csmproblem == null){
            return NotFound();
        }
        try {
            db.Csmproblem.Remove(csmproblem);
            db.SaveChanges();
        } catch (Exception ex) {
            return Ok(new { mesg=ex.ToString()});
        }
        return Ok();
    }
}