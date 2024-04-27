using HMS.DAL.Data;
using HMS.Models.NumberGeneratorHelper;
using HMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hospital_Management_System.Helpers;

namespace Hospital_Management_System.Controllers
{
    [Route("api/tickets")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public TicketController(HospitalDbContext context)
        {
            _context = context;
        }

        // POST api/tickets
        [HttpPost]
        public ActionResult<Ticket> PostTicket([FromForm] Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var numberGenerator = new NumberGeneratorHelper(_context);
            ticket.TicketNumber = numberGenerator.GenerateNumber();
            ticket.TicketDate = DateTime.Now;

            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetTickets), new { id = ticket.TicketID }, ticket);
        }

        // GET api/tickets
        [HttpGet]
        public ActionResult<IEnumerable<Ticket>> GetTickets()
        {
            var tickets = _context.Tickets.ToList();
            return Ok(tickets);
        }
    }


}
