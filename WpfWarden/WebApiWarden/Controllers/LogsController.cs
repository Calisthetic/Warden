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
    public class LogsController : ApiController
    {
        private WardenEntities db = new WardenEntities();

        //// GET: api/Logs
        //public IQueryable<Logs> GetLogs()
        //{
        //    return db.Logs;
        //}

        [Route("api/Logs")]
        public List<ResponseLogs> GetLogs(int skip = 0, int take = 10, string logLevel = "null", bool showOld = false, int userId = 0, string search = "null")
        {
            //var logs = db.Logs.OrderByDescending(x => x.Logged).Skip(skip).Take(take).ToList().ConvertAll(x => new ResponseLogs(x));

            var logs = db.Logs.ToList();
            if (logLevel != "null")
                logs = logs.Where(x => x.LogLevel == logLevel).ToList();
            
            if (showOld == true) // Sort by date
                logs = logs.OrderBy(x => x.Logged).ToList();
            else
                logs = logs.OrderByDescending(x => x.Logged).ToList();

            if (userId > 0) // Fing by userId
                logs = logs.Where(x => x.UserId == userId).ToList();

            if (!string.IsNullOrWhiteSpace(search) && search != "null") // Search in message or exception
            {
                logs = logs.Where(x => (x.Exception == null) ? (x.Message.ToLower().Contains(search.ToLower())) // if Exception == null
                : ((x.Message == null) ? (x.Exception.ToLower().Contains(search.ToLower())) // if Message == null
                : (x.Message.ToLower().Contains(search.ToLower()) || x.Exception.ToLower().Contains(search.ToLower())))).ToList();
            }

            return logs.Skip(skip).Take(take).ToList().ConvertAll(x => new ResponseLogs(x));
        }

        [Route("api/LogsCount")]
        public int GetLogs(int skip = 0, string logLevel = "null", bool showOld = false, int userId = 0, string search = "null")
        {
            var logs = db.Logs.ToList();
            if (logLevel != "null")
                logs = logs.Where(x => x.LogLevel == logLevel).ToList();

            if (showOld == true) // Sort by date
                logs = logs.OrderBy(x => x.Logged).ToList();
            else
                logs = logs.OrderByDescending(x => x.Logged).ToList();

            if (userId > 0) // Fing by userId
                logs = logs.Where(x => x.UserId == userId).ToList();

            if (!string.IsNullOrWhiteSpace(search) && search != "null") // Search in message or exception
            {
                logs = logs.Where(x => (x.Exception == null) ? (x.Message.ToLower().Contains(search.ToLower())) // if Exception == null
                : ((x.Message == null) ? (x.Exception.ToLower().Contains(search.ToLower())) // if Message == null
                : (x.Message.ToLower().Contains(search.ToLower()) || x.Exception.ToLower().Contains(search.ToLower())))).ToList();
            }

            return logs.Skip(skip).Count();
        }

        // GET: api/Logs/5
        [ResponseType(typeof(Logs))]
        public IHttpActionResult GetLogs(int id)
        {
            Logs logs = db.Logs.Find(id);
            if (logs == null)
            {
                return NotFound();
            }

            return Ok(logs);
        }

        // PUT: api/Logs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLogs(int id, Logs logs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != logs.LogId)
            {
                return BadRequest();
            }

            db.Entry(logs).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogsExists(id))
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

        // POST: api/Logs
        [ResponseType(typeof(Logs))]
        public IHttpActionResult PostLogs(Logs logs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Logs.Add(logs);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = logs.LogId }, logs);
        }

        // DELETE: api/Logs/5
        [ResponseType(typeof(Logs))]
        public IHttpActionResult DeleteLogs(int id)
        {
            Logs logs = db.Logs.Find(id);
            if (logs == null)
            {
                return NotFound();
            }

            db.Logs.Remove(logs);
            db.SaveChanges();

            return Ok(logs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LogsExists(int id)
        {
            return db.Logs.Count(e => e.LogId == id) > 0;
        }
    }
}