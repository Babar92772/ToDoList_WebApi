using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;



namespace ToDoList_WebAPI.Controllers
{
    [RoutePrefix("api/TaskApi")]
    //[DataContract]
    public class TaskApiController : ApiController
    {
        // GET: TaskApi
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("All")]
        public IHttpActionResult GetAllAsync()
        {
            var contexte = new ToDoListWebAPI20180823030718_dbEntities();
            var tasks = contexte.Tasks.OrderBy(n => n.ID).ToList();
            

            //var toto = "";
            //foreach (var item in tasks)
            //{
            //    toto += " / " + "{id: " + item.ID + ", Note: " + item.Note + ", State: " + item.TaskState + " }";
            //}
            //return Ok(toto);

            return Ok(tasks);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("Todo/{iduser}")]
        public IHttpActionResult GetToDo(int iduser)
        {
            var contexte = new ToDoListWebAPI20180823030718_dbEntities();
            var tasks = contexte.Tasks.Where(n => n.TaskState == "todo" & n.IDUserCreator == iduser).OrderBy(n => n.ID).ToList();
            return Ok(tasks);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("Progress/{iduser}")]
        public IHttpActionResult GetProgress(int iduser)
        {
            var contexte = new ToDoListWebAPI20180823030718_dbEntities();
            var tasks = contexte.Tasks.Where(n => n.TaskState == "progress" & n.IDUserCreator == iduser).OrderBy(n => n.ID).ToList();
            return Ok(tasks);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("Done/{iduser}")]
        public IHttpActionResult GetDone(int iduser)
        {
            var contexte = new ToDoListWebAPI20180823030718_dbEntities();
            var tasks = contexte.Tasks.Where(n => n.TaskState == "done" & n.IDUserCreator == iduser).OrderBy(n => n.ID).ToList();
            return Ok(tasks);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var contexte = new ToDoListWebAPI20180823030718_dbEntities();
            var task = contexte.Tasks.Where(n => n.ID == id).FirstOrDefault();

            //var toto = "{id: " + task.ID + ", Note: " + task.Note + ", State: " + task.TaskState + " }";
            //return Ok(toto);

            return Ok(task);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("ADD/{task}")]
        public IHttpActionResult PostAdd(Tasks task)
        {
            var contexte = new ToDoListWebAPI20180823030718_dbEntities();
            contexte.Tasks.Add(task);
            contexte.SaveChanges();
            return Ok();
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("EDIT/{task}")]
        public IHttpActionResult Put(Tasks task)
        {
            var contexte = new ToDoListWebAPI20180823030718_dbEntities();
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

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("DEL/{id}")]
        public IHttpActionResult Delete(int id)
        {
            var contexte = new ToDoListWebAPI20180823030718_dbEntities();
            var task = contexte.Tasks.Where(n => n.ID == id).FirstOrDefault();
            List<Comments> comments = contexte.Comments.Where(n => n.IDTask == id).ToList();
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