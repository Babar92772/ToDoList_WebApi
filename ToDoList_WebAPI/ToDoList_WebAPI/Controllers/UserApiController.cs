using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ToDoList_WebAPI.Controllers
{
    [RoutePrefix("api/UserApi")]
    public class UserApiController : ApiController
    {
        // GET: User
        [Route("All")]
        public IHttpActionResult Get()
        {
            var contexte = new ToDoListEntities();
            var tasks = contexte.Tasks.OrderBy(n => n.ID).ToList();
            return Ok(tasks);
        }

        //[Route("{ID}")]
        //public IHttpActionResult Get(int ID)
        //{
        //    var contexte = new ToDoListEntities();
        //    var user = contexte.Users.Where(n => n.ID == ID).FirstOrDefault();
        //    return Ok(user);
        //}

        [Route("Mail/{ID}")]
        public IHttpActionResult GetMailById(int ID)
        {
            var contexte = new ToDoListEntities();
            var user = contexte.Users.Where(n => n.ID == ID).FirstOrDefault();
            return Ok(user.Mail);
        }

        [Route("ADD/{user}")]
        public IHttpActionResult Post(Users user)
        {
            var contexte = new ToDoListEntities();
            contexte.Users.Add(user);
            contexte.SaveChanges();

            return Ok();
        }

        [Route("DEL/{ID}")]
        public IHttpActionResult Delete(int ID)
        {
            var contexte = new ToDoListEntities();
            var user = contexte.Users.Where(n => n.ID == ID).FirstOrDefault();
            contexte.Users.Remove(user);
            contexte.SaveChanges();
            return Ok();
        }
    }
}