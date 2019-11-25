using ClassLibrary1.Models;
using SehirRehberiApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SehirRehberiApp.Controllers 
{
    public class AngController : ApiController
    {

       
        AppDbContext _ctx = new AppDbContext();
        [HttpGet]
        [ActionName("getMethod")]
        public IHttpActionResult getMethod()
        {
            var obj = _ctx.UserProperties.ToList();

            return Ok(new { results = obj });
        }
    }
}
