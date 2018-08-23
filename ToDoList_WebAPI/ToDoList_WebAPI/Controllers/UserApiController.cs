using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ToDoList_WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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

        

        [Route("ADD/{user}")]
        public IHttpActionResult Post(Users user)
        {
            var contexte = new ToDoListEntities();
            contexte.Users.Add(user);
            contexte.SaveChanges();

            return Ok();
        }

        [Route("EDIT/{user}")]
        public IHttpActionResult Put(Users user)
        {
            var contexte = new ToDoListEntities();
            var userEdit = contexte.Users.Where(n => n.ID == user.ID).FirstOrDefault();
            userEdit.Mail = user.Mail;
            userEdit.Pwd = user.Pwd;
            contexte.SaveChanges();
            return Ok();
        }

        [Route("DEL/{ID}")]
        public IHttpActionResult Delete(int ID)
        {
            var contexte = new ToDoListEntities();
            var user = contexte.Users.Where(n => n.ID == ID).FirstOrDefault();
            List<Comments> comments = contexte.Comments.Where(n => n.IDTask == ID).ToList();
            foreach (var item in comments)
            {
                item.IDTask = 14785;
                contexte.SaveChanges();
            }
            contexte.Users.Remove(user);
            contexte.SaveChanges();
            return Ok();
        }
    }
}