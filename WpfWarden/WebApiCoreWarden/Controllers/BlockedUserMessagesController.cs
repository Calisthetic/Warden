using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCoreWarden.Models;

namespace WebApiCoreWarden.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockedUserMessagesController : ControllerBase
    {
        private readonly WardenContext _context;

        public BlockedUserMessagesController(WardenContext context)
        {
            _context = context;
        }

        // GET: api/BlockedUserMessages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlockedUserMessage>>> GetBlockedUserMessages()
        {
          if (_context.BlockedUserMessages == null)
          {
              return NotFound();
          }
            return await _context.BlockedUserMessages.ToListAsync();
        }

        // GET: api/BlockedUserMessages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<BlockedUserMessage>>> GetBlockedUserMessage(int id)
        {
            if (_context.BlockedUserMessages == null)
            {
                return NotFound();
            }
            var blockedUserMessage = await _context.BlockedUserMessages.Where(x => x.SendlerUserId == id || x.DestinationUserId == id).Include(x1 => x1.SendlerUser).ToListAsync();

            if (blockedUserMessage == null)
            {
                return NotFound();
            }

            return blockedUserMessage;
        }

        // PUT: api/BlockedUserMessages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlockedUserMessage(int id, BlockedUserMessage blockedUserMessage)
        {
            if (id != blockedUserMessage.BlockedUserMessageId)
            {
                return BadRequest();
            }

            _context.Entry(blockedUserMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlockedUserMessageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BlockedUserMessages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BlockedUserMessage>> PostBlockedUserMessage(BlockedUserMessage blockedUserMessage)
        {
          if (_context.BlockedUserMessages == null)
          {
              return Problem("Entity set 'WardenContext.BlockedUserMessages'  is null.");
          }
            _context.BlockedUserMessages.Add(blockedUserMessage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlockedUserMessage", new { id = blockedUserMessage.BlockedUserMessageId }, blockedUserMessage);
        }

        // DELETE: api/BlockedUserMessages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlockedUserMessage(int id)
        {
            if (_context.BlockedUserMessages == null)
            {
                return NotFound();
            }
            var blockedUserMessage = await _context.BlockedUserMessages.FindAsync(id);
            if (blockedUserMessage == null)
            {
                return NotFound();
            }

            _context.BlockedUserMessages.Remove(blockedUserMessage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlockedUserMessageExists(int id)
        {
            return (_context.BlockedUserMessages?.Any(e => e.BlockedUserMessageId == id)).GetValueOrDefault();
        }
    }
}
