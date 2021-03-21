using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerNotification.API.Models;
using CustomerNotification.API.Data;
using CustomerNotificaton.Services;

namespace CustomerNotification.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MessageContext _context;

        public MessageController(MessageContext context)
        {
            _context = context;
        }

        public async void Notifiy(string customerId, string messageBody)
        {
            MessagingService note = new MessagingService();

            await note.SendMessageAsync(customerId, messageBody);

        }
        // GET: api/Message
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
            return await _context.Messages.ToListAsync();
        }

        // GET: api/Message/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage(string id)
        {
            var message = await _context.Messages.FindAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }

        // PUT: api/Message/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutMessage(UserBlocked message)
        {
            if (!message.messageType.Equals("UserBlocked")) return BadRequest();

            var data = await _context.Messages.FindAsync(message.data.UserId);
            if (data == null)
            {
                Notifiy(message.data.UserId, "No UserId Found");
                return NotFound();
            }
            _context.Entry(data).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(message.data.UserId))
                {
                    Notifiy(message.data.UserId, "No User Found");
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            Notifiy(message.data.UserId, "Updated");
            return Ok();
        }

        // POST: api/Message
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage(NewUserRegistered message)
        {
            if (!message.messageType.Equals("NewUserRegistered")) return BadRequest();

            var data = await _context.Messages.FindAsync(message.data.UserId);
            if (data != null)
            {
                Notifiy(message.data.UserId, "Same UserId exist");
                return BadRequest();
            }

            _context.Messages.Add(message.data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MessageExists(message.data.UserId))
                {
                    Notifiy(message.data.UserId, "Conflit");
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            Notifiy(message.data.UserId, "Created");
            return CreatedAtAction("GetMessage", new { id = message.data.UserId }, message);
        }

        // DELETE: api/Message/5
        [HttpDelete]
        public async Task<IActionResult> DeleteMessage(UserDeleted message)
        {
            if (!message.messageType.Equals("UserDeleted")) return BadRequest();
            var data = await _context.Messages.FindAsync(message.data.UserId);
            if (data == null)
            {
                Notifiy(message.data.UserId, "No UserId Found");
                return NotFound();
            }

            _context.Messages.Remove(data);
            await _context.SaveChangesAsync();
            Notifiy(message.data.UserId, "Deleted");
            return Ok();
        }

        private bool MessageExists(string UserId)
        {
            return _context.Messages.Any(e => e.UserId == UserId);
        }
    }
}
