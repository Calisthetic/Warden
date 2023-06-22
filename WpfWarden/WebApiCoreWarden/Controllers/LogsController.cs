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
    public class LogsController : ControllerBase
    {
        private readonly WardenContext _context;

        public LogsController(WardenContext context)
        {
            _context = context;
        }

        // GET: api/Logs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Log>>> GetLogs(int skip = 0, int take = 10, string logLevel = "", bool showOld = false, int userId = 0, string search = "")
        {
            if (_context.Logs == null)
            {
                return NotFound();
            }
            var logs = _context.Logs.Include(x => x.User).ThenInclude(x1 => x1.Permission).Include(x1 => x1.User).ThenInclude(x1 => x1.Division).ToList();
            if (!string.IsNullOrEmpty(logLevel))
                logs = logs.Where(x => x.LogLevel == logLevel).ToList();

            if (showOld == true) // Sort by date
                logs = logs.OrderBy(x => x.Logged).ToList();
            else
                logs = logs.OrderByDescending(x => x.Logged).ToList();

            if (userId > 0) // Fing by userId
                logs = logs.Where(x => x.UserId == userId).ToList();

            if (!string.IsNullOrWhiteSpace(search)) // Search in message or exception
            {
                logs = logs.Where(x => (x.Exception != null) ? (x.Exception.ToLower().Contains(search.ToLower())) // if Exception == null
                : ((x.Message != null) ? (x.Message.ToLower().Contains(search.ToLower())) // if Message == null
                : (x.Message.ToLower().Contains(search.ToLower()) || x.Exception.ToLower().Contains(search.ToLower())))).ToList();
            }

            return logs.Skip(skip).Take(take).ToList();
        }

        [HttpGet("Count")]
        public async Task<int> GetLogsCount(int skip = 0, string logLevel = "null", bool showOld = false, int userId = 0, string search = "null")
        {
            var logs = _context.Logs.Include(x => x.User).Include(x1 => x1.User.Permission).Include(x1 => x1.User.Division).ToList();
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
        [HttpGet("{id}")]
        public async Task<ActionResult<Log>> GetLog(int id)
        {
          if (_context.Logs == null)
          {
              return NotFound();
          }
            var log = await _context.Logs.FindAsync(id);

            if (log == null)
            {
                return NotFound();
            }

            return log;
        }

        // PUT: api/Logs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLog(int id, Log log)
        {
            if (id != log.LogId)
            {
                return BadRequest();
            }

            _context.Entry(log).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogExists(id))
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

        // POST: api/Logs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Log>> PostLog(Log log)
        {
          if (_context.Logs == null)
          {
              return Problem("Entity set 'WardenContext.Logs'  is null.");
          }
            _context.Logs.Add(log);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLog", new { id = log.LogId }, log);
        }

        // DELETE: api/Logs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLog(int id)
        {
            if (_context.Logs == null)
            {
                return NotFound();
            }
            var log = await _context.Logs.FindAsync(id);
            if (log == null)
            {
                return NotFound();
            }

            _context.Logs.Remove(log);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LogExists(int id)
        {
            return (_context.Logs?.Any(e => e.LogId == id)).GetValueOrDefault();
        }
    }
}
