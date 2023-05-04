using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiWarden.Models;

namespace WebApiWarden.Controllers
{
    public class UsersController : ApiController
    {
        private WardenEntities db = new WardenEntities();

        // GET: api/Users
        //public IQueryable<Users> GetUsers()
        //{
        //    return db.Users;
        //}

        [Route("api/Users")]
        public IQueryable<Users> GetUsers()
        {
            return db.Users;
        }
        [Route("api/Users")]
        public IQueryable<Users> GetVerifiedUsers(bool IsVerify)
        {
            return db.Users.Where(x => x.IsVerify == IsVerify);
        }
        [Route("api/Users")]
        public IQueryable<Users> GetBlockedUsers(bool IsBlocked)
        {
            return db.Users.Where(x => x.IsBlocked == IsBlocked);
        }
        [Route("api/Users")]
        [ResponseType(typeof(Users))]
        public IHttpActionResult GetAuthUsers(string login, string password, int divisionId)
        {
            Users user = db.Users.FirstOrDefault(x => x.Login == login && x.Password == password && x.DivisionId == divisionId);
            if (user == null)
                return NotFound();
            else
                return Ok(user);
        }

        // http://localhost:54491/api/UsersMessages
        [Route("api/UsersMessages")]
        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUsersMessages()
        {
            return Ok(db.Users.Where(x => x.IsBlocked == true).ToList().ConvertAll(p => new ResponseUsersMessage(p)));
        }

        // GET: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsers(int id, Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.UserId)
            {
                return BadRequest();
            }

            db.Entry(users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(Users))]
        public IHttpActionResult PostUsers(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(users);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = users.UserId }, users);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult DeleteUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            db.Users.Remove(users);
            db.SaveChanges();

            return Ok(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersExists(int id)
        {
            return db.Users.Count(e => e.UserId == id) > 0;
        }
    }
}