using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ToDoList_WebAPI.Controllers
{
    [RoutePrefix("api/UserApi")]
    public class UserApiController : ApiController
    {
        // GET: User
        public IHttpActionResult Get()
        {
            return Ok("test");
        }
    }
}