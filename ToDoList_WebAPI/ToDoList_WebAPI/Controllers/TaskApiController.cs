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

        [Route("ADD/{task}")]
        public IHttpActionResult PostAdd(Tasks task)
        {
            var contexte = new ToDoListEntities();
            contexte.Tasks.Add(task);
            contexte.SaveChanges();
            return Ok();
        }

        //[Route("EDIT/{task}")]
        //public IHttpActionResult PostEdit(Tasks task)
        //{
        //    var contexte = new ToDoListEntities();
        //    var taskEdit = contexte.Tasks.Where(n => n.ID == task.ID).FirstOrDefault();
        //    taskEdit.TaskState = task.TaskState;
        //    taskEdit.Note = task.Note;
        //    taskEdit.DeadLine = task.DeadLine;
        //    taskEdit.TaskState = task.TaskState;

        //    contexte.SaveChanges();
        //    return Ok();
        //}

        [Route("DEL/{ID}")]
        public IHttpActionResult Delete(int ID)
        {
            var contexte = new ToDoListEntities();
            Tasks task = contexte.Tasks.Where(n => n.ID == ID).FirstOrDefault();
            List<Comments> comments = contexte.Comments.Where(n => n.IDTask == ID).ToList();
            foreach (var item in comments)
            {
                contexte.Comments.Remove(item);
            }
            //task.Users1 = new List<Users>();
            contexte.Tasks.Remove(task);
            contexte.SaveChanges();
            return Ok();
        }
    }
}