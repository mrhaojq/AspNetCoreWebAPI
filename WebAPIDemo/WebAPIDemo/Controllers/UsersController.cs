using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IEnumerable<UserForProto> _users;
        public UsersController()
        {
            _users = new UserForProto[] {
                new UserForProto(){ Id=1,Name="Tom",Age=30},
                new UserForProto(){ Id=2,Name="Jack",Age=20}
            };
        }

        [HttpGet("Proto")]
        [Produces("application/proto")]
        public IEnumerable<UserForProto> GetProto()
        {
            return _users;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Web API", "ASP.NET CORE" };
        }

        [HttpGet("Json")]
        //public JsonResult GetJson()//
        public IActionResult GetJson()//与public JsonResult GetJson()等效
        {
            return Json(new { key = "Web API", value = "ASP.NET CORE" });
        }

        [HttpGet("Content")]
        //public ContentResult GetContent()
        public IActionResult GetContent()//与public ContentResult GetContent()等效
        {
            return Content("An API listing anthors of docs.asp.net.");
        }

        [HttpGet("String")]
        public string GetString()
        {
            return "Version 1.0.0";
        }

    
        //[HttpGet("Xml")]
        //public User GetXml()
        //{
        //    User u = new User { Name="Hao",Age=30};
        //    return u;
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "User ID-" + id;
        }
    }


}
