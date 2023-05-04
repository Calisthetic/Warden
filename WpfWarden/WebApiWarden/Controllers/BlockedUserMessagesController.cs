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
    public class BlockedUserMessagesController : ApiController
    {
        private WardenEntities db = new WardenEntities();

        // GET: api/BlockedUserMessages
        public IQueryable<BlockedUserMessages> GetBlockedUserMessages()
        {
            return db.BlockedUserMessages;
        }

        [Route("api/Messages")]
        [ResponseType(typeof(BlockedUserMessages))]
        public IHttpActionResult GetBlockedUserMessages(int userId)
        {
            List<Messages> blockedUserMessages = db.BlockedUserMessages.Where(x => x.SendlerUserId == userId || x.DestinationUserId == userId).ToList().ConvertAll(x => new Messages(x));
            if (blockedUserMessages.Count == 0)
            {
                return NotFound();
            }

            return Ok(blockedUserMessages);
        }

        // GET: api/BlockedUserMessages/5
        //[ResponseType(typeof(BlockedUserMessages))]
        //public IHttpActionResult GetBlockedUserMessages(int id)
        //{
        //    BlockedUserMessages blockedUserMessages = db.BlockedUserMessages.Find(id);
        //    if (blockedUserMessages == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(blockedUserMessages);
        //}

        // PUT: api/BlockedUserMessages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBlockedUserMessages(int id, BlockedUserMessages blockedUserMessages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != blockedUserMessages.BlockedUserMessageId)
            {
                return BadRequest();
            }

            db.Entry(blockedUserMessages).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlockedUserMessagesExists(id))
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

        // POST: api/BlockedUserMessages
        [ResponseType(typeof(BlockedUserMessages))]
        public IHttpActionResult PostBlockedUserMessages(BlockedUserMessages blockedUserMessages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BlockedUserMessages.Add(blockedUserMessages);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = blockedUserMessages.BlockedUserMessageId }, blockedUserMessages);
        }

        // DELETE: api/BlockedUserMessages/5
        [ResponseType(typeof(BlockedUserMessages))]
        public IHttpActionResult DeleteBlockedUserMessages(int id)
        {
            BlockedUserMessages blockedUserMessages = db.BlockedUserMessages.Find(id);
            if (blockedUserMessages == null)
            {
                return NotFound();
            }

            db.BlockedUserMessages.Remove(blockedUserMessages);
            db.SaveChanges();

            return Ok(blockedUserMessages);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BlockedUserMessagesExists(int id)
        {
            return db.BlockedUserMessages.Count(e => e.BlockedUserMessageId == id) > 0;
        }
    }
}