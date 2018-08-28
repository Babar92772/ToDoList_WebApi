using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ToDoList_WebAPI.Controllers
{
    [RoutePrefix("api/CommentApi")]
    public class CommentApiController : ApiController
    {
        // GET: CommentApi
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var contexte = new ToDoListWebAPI20180823030718_dbEntities();
            var comment = contexte.Comments.Where(n => n.ID == id).FirstOrDefault();
            return Ok(comment);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("Task/{idtask}")]
        public IHttpActionResult GetComByTask(int idtask)
        {
            var contexte = new ToDoListWebAPI20180823030718_dbEntities();
            var comments = contexte.Comments.Where(n => n.IDTask == idtask).FirstOrDefault();
            return Ok(comments);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("ADD/{Com}")]
        public IHttpActionResult Post(Comments Com)
        {
            var contexte = new ToDoListWebAPI20180823030718_dbEntities();
            contexte.Comments.Add(Com);
            contexte.SaveChanges();

            return Ok();
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("EDIT/{Com}")]
        public IHttpActionResult Put(Comments Com)
        {
            var contexte = new ToDoListWebAPI20180823030718_dbEntities();
            var comEdit = contexte.Comments.Where(n => n.ID == Com.ID).FirstOrDefault();
            comEdit.Content = Com.Content;
            contexte.SaveChanges();
            return Ok();
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("DEL/{id}")]
        public IHttpActionResult Delete(int id)
        {
            var contexte = new ToDoListWebAPI20180823030718_dbEntities();
            var comment = contexte.Comments.Where(n => n.ID == id).FirstOrDefault();
            contexte.Comments.Remove(comment);
            contexte.SaveChanges();
            return Ok();
        }
    }
}