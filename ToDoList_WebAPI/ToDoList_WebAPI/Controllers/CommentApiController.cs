using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ToDoList_WebAPI.Controllers
{
    [RoutePrefix("api/CommentApi")]
    public class CommentApiController : ApiController
    {
        // GET: CommentApi
        [Route("{ID}")]
        public IHttpActionResult Get(int ID)
        {
            var contexte = new ToDoListEntities();
            var comment = contexte.Comments.Where(n => n.ID == ID).FirstOrDefault();
            return Ok(comment);
        }

        [Route("{idtask}")]
        public IHttpActionResult GetComByTask(int idtask)
        {
            var contexte = new ToDoListEntities();
            var comments = contexte.Comments.Where(n => n.IDTask == idtask).FirstOrDefault();
            return Ok(comments);
        }

        [Route("ADD/{Com}")]
        public IHttpActionResult Post(Comments Com)
        {
            var contexte = new ToDoListEntities();
            contexte.Comments.Add(Com);
            contexte.SaveChanges();

            return Ok();
        }


        [Route("DEL/{ID}")]
        public IHttpActionResult Delete(int ID)
        {
            var contexte = new ToDoListEntities();
            var comment = contexte.Comments.Where(n => n.ID == ID).FirstOrDefault();
            contexte.Comments.Remove(comment);
            contexte.SaveChanges();
            return Ok();
        }
    }
}