using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ToDoList_WebAPI.Controllers
{
    [RoutePrefix("api/UserConnexion")]
    public class UserConnexionController : ApiController
    {
        //Retourne l'information si les identifiants envoyés sont existant dans la base de donner, pour la connexion
        [Route("Connect/{mail}/{pwd}")]
        public IHttpActionResult GetValdByMailAndPwd(string mail, string pwd)
        {
            var contexte = new ToDoListEntities();
            var User = contexte.Users.Where(n => n.Mail == mail & n.Pwd == pwd).FirstOrDefault();
            bool retour;
            if (User == null)
            {
                retour = false;
            }
            else
            {
                retour = true;
            }

            return Ok(retour);
        }

        //[Route("")]
        //public IHttpActionResult Get()
        //{
        //    return Ok("test");
        //}
    }
}