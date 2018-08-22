using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ToDoList_WebAPI.Controllers
{
    [RoutePrefix("api/TaskApi")]
    public class TaskApiController : ApiController
    {
        // GET: TaskApi
        [Route("")]
        public IHttpActionResult Get()
        {
            var contexte = new ToDoListEntities();
            //var toto = "";
            var tasks = contexte.Tasks.OrderBy(n => n.ID).ToList();
            //foreach (var item in tasks)
            //{
            //    toto += " / " + "{id: " + item.ID + ", Note: " + item.Note + ", State: " + item.TaskState + " }";
            //}
            //return Ok(toto);
            return Ok(tasks);
        }

        [Route("{ID}")]
        public IHttpActionResult Get(int ID)
        {
            var contexte = new ToDoListEntities();
            var task = contexte.Tasks.Where(n => n.ID == ID).FirstOrDefault();
            //var toto = "{id: " + task.ID + ", Note: " + task.Note + ", State: " + task.TaskState + " }";
            return Ok(task);
            //return Ok(toto);
        }
    }
}