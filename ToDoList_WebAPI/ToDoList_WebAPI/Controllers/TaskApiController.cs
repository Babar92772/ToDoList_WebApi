using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ToDoList_WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/TaskApi")]
    public class TaskApiController : ApiController
    {
        // GET: TaskApi
        [Route("All")]
        public IHttpActionResult GetAll()
        {
            var contexte = new ToDoListEntities();
            var tasks = contexte.Tasks.OrderBy(n => n.ID).ToList();

            //var toto = "";
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
            //return Ok(toto);

            return Ok(task);
        }

        [Route("ADD/{task}")]
        public IHttpActionResult PostAdd(Tasks task)
        {
            var contexte = new ToDoListEntities();
            contexte.Tasks.Add(task);
            contexte.SaveChanges();
            return Ok();
        }

        [Route("EDIT/{task}")]
        public IHttpActionResult Put(Tasks task)
        {
            var contexte = new ToDoListEntities();
            var taskEdit = contexte.Tasks.Where(n => n.ID == task.ID).FirstOrDefault();
            taskEdit.TaskState = task.TaskState;
            taskEdit.Note = task.Note;
            taskEdit.DeadLine = task.DeadLine;
            //contexte.Tasks.;
            contexte.SaveChanges();
            return Ok();
        }

        //[Route("EDIT/{id}/{taskState}/{note}/{deadLine}")]
        //public IHttpActionResult Put(int id, string taskState, string note, DateTime deadLine)
        //{
        //    var contexte = new ToDoListEntities();
        //    var taskEdit = contexte.Tasks.Where(n => n.ID == id).FirstOrDefault();
        //    taskEdit.TaskState = taskState;
        //    taskEdit.Note = note;
        //    taskEdit.DeadLine = deadLine;
        //    //contexte.Tasks.;
        //    contexte.SaveChanges();
        //    return Ok();
        //}

        [Route("DEL/{ID}")]
        public IHttpActionResult Delete(int ID)
        {
            var contexte = new ToDoListEntities();
            var task = contexte.Tasks.Where(n => n.ID == ID).FirstOrDefault();
            List<Comments> comments = contexte.Comments.Where(n => n.IDTask == ID).ToList();
            foreach (var item in comments)
            {
                contexte.Comments.Remove(item);
            }
            
            contexte.Tasks.Remove(task);
            contexte.SaveChanges();
            return Ok();
        }
    }
}