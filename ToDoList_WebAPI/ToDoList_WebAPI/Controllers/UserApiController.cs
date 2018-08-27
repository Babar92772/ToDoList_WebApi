using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ToDoList_WebAPI.Controllers
{
    [RoutePrefix("api/UserApi")]
    public class UserApiController : ApiController
    {
        // GET: User
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("All")]
        public IHttpActionResult Get()
        {
            var contexte = new ToDoListWebAPI20180823030718_dbEntities();
            var users = contexte.Users.OrderBy(n => n.ID).ToList();
            return Ok(users);
        }

        //[Route("{ID}")]
        //public IHttpActionResult Get(int ID)
        //{
        //    var contexte = new ToDoListEntities();
        //    var user = contexte.Users.Where(n => n.ID == ID).FirstOrDefault();
        //    return Ok(user);
        //}

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("ADD/{user}")]
        public IHttpActionResult Post(Users user)
        {
            var contexte = new ToDoListWebAPI20180823030718_dbEntities();
            contexte.Users.Add(user);
            contexte.SaveChanges();

            return Ok();
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("EDIT/{user}")]
        public IHttpActionResult Put(Users user)
        {
            var contexte = new ToDoListWebAPI20180823030718_dbEntities();
            var userEdit = contexte.Users.Where(n => n.ID == user.ID).FirstOrDefault();
            userEdit.Mail = user.Mail;
            userEdit.Pwd = user.Pwd;
            contexte.SaveChanges();
            return Ok();
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("DEL/{id}")]
        public IHttpActionResult Delete(int id)
        {
            var contexte = new ToDoListWebAPI20180823030718_dbEntities();
            var user = contexte.Users.Where(n => n.ID == id).FirstOrDefault();
            List<Comments> comments = contexte.Comments.Where(n => n.IDUser == id).ToList();
            foreach (var item in comments)
            {
                item.IDUser = 14785;
                contexte.SaveChanges();
            }
            contexte.Users.Remove(user);
            contexte.SaveChanges();
            return Ok();
        }
    }
}