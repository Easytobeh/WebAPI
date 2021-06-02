using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Database;

namespace WebApi.Controllers
{
    public class UserController : ApiController
    {
        //[HttpGet]
        //public string Greet(string name)
        //{
        //    return "Welcome " + name;
        //}
        DataBaseContext db = new DataBaseContext();

        //api/User/
        public IEnumerable<User> GetUsers()
        {
            return db.Users.ToList();
        }

        //api/User/2
        public User GetUsers(int id)
        {
            return db.Users.Find(id);
        }

        [HttpPost]
        public HttpResponseMessage AddUser (User model)
        {
            try
            {
                db.Users.Add(model);
                db.SaveChanges();
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created);
                return response;
            }
            catch (Exception)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return response;
            }
        }

        public HttpResponseMessage UpdateUser(int id, User model)
        {
            try
            {
                if(id == model.UserId)
                {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    return response;

                }
                else
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotModified);
                    return response;
                }
            }
            catch (Exception)
            {

                HttpResponseMessage response = new HttpResponseMessage();
                return response;
            }
        }

        public HttpResponseMessage DeleteUser(int id)
        {
            try
            {
                User user = db.Users.Find(id);
                if(user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
               else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                
            }
        }

    }
}
