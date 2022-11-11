using Microsoft.AspNetCore.Mvc;
using CSMAPI.Models;

using Microsoft.AspNetCore.Authorization;

namespace CSMAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class usersController : ControllerBase
{
    private readonly ILogger<usersController> _logger;

    public usersController(ILogger<usersController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    //[Authorize(Roles = "user")]
    public IActionResult Get()
    {
        try {
            var db = new CSMDbContext();
            var users = from a in db.User select new{User_ID = a.UserId, First_Name = a.FName, Last_Name = a.LName, Phone_Number = a.PhoneNum};
            return Ok(users);

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

            var user = db.User.Find(id);
            if (user == null) return NotFound();
            return Ok(user);
        } catch (Exception e) {
            return Ok(new { mesg=e.ToString()});
        }
    }
    
    [HttpPost]
    //[Authorize(Roles = "user")]
    public IActionResult Post([FromBody] DTOs.User data)
    {
        try {
            var db = new CSMDbContext();

            var users = new User();
            users.UserId = data.UserId;
            users.Password = data.Password;
            users.FName = data.FName;
            users.LName = data.LName;
            users.PhoneNum = data.PhoneNum;

            db.User.Add(users);
            db.SaveChanges();

            return Ok();

        } catch (Exception e) {
            return Ok(new { mesg=e.ToString()});
        }
    }

    [HttpPut]
    //[Authorize(Roles = "user")]
    public IActionResult Put([FromBody] DTOs.User data)
    {
        try {
            var db = new CSMDbContext();

            var users = db.User.Find(data.UserId);
            if (users == null) return NotFound();

            users.Password = data.Password;
            users.FName = data.FName;
            users.LName = data.LName;
            users.PhoneNum = data.PhoneNum;

            db.SaveChanges();

            return Ok();
        } catch (Exception e) {
            return Ok(new { mesg=e.ToString()});
        }
    }

    [Route("{id}")]
    [HttpDelete]
    //[Authorize(Roles = "user")]
    public IActionResult Delete(string id)
    {
        var db = new CSMDbContext();
        var user = db.User.Find(id);
        if (user == null) return NotFound();
        try {
            db.User.Remove(user);
            db.SaveChanges();
        } catch (Exception ex) {
            return Ok(new { mesg=ex.ToString()});
        }
        return Ok();
    }
}