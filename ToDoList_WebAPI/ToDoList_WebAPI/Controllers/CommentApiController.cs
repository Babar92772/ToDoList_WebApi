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
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var contexte = new ToDoListEntities();
            var comment = contexte.Comments.Where(n => n.ID == id).FirstOrDefault();
            return Ok(comment);
        }

        [Route("Task/{idtask}")]
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

        [Route("EDIT/{Com}")]
        public IHttpActionResult Put(Comments Com)
        {
            var contexte = new ToDoListEntities();
            var comEdit = contexte.Comments.Where(n => n.ID == Com.ID).FirstOrDefault();
            comEdit.Content = Com.Content;
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