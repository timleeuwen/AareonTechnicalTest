using AareonTechnicalTest.Managers;
using AareonTechnicalTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AareonTechnicalTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ILogger<TicketsController> _logger;
        private readonly ITicketManager _ticketManager;
        private readonly INoteManager _noteManager;

        public TicketsController(ILogger<TicketsController> logger, ITicketManager ticketManager, INoteManager noteManager)
        {
            _logger = logger;
            _ticketManager = ticketManager;
            _noteManager = noteManager;
        }

        /// <summary>
        /// Use this method to get all the tickets
        /// </summary>
        /// <returns>A list of all the tickets</returns>
        [HttpGet]
        public IActionResult GetAllTickets()
        {
            //TODO Unit Tests

            // Log that all tickets was called
            _logger.LogInformation($"{nameof(TicketsController)}.{nameof(GetAllTickets)} called");

            // For now, I will just return a couple of tickets
            var tickets = _ticketManager.GetAllTickets();

            //TODO make sure method handles NULL result

            // Return tickets
            return Ok(tickets);
        }

        /// <summary>
        /// Get a specific ticket by its Id
        /// </summary>
        /// <param name="ticketId">The Id of the ticket you are looking for</param>
        /// <returns>The ticket that matches the Id, or a NotFound result when the ticket does not exist</returns>
        [HttpGet("{ticketId:int:min(1)}")]
        public IActionResult GetTicketById(int ticketId)
        {
            //TODO Unit Tests

            // Log that method was called
            _logger.LogInformation($"{nameof(TicketsController)}.{nameof(GetTicketById)} called");

            // Get the ticket by the Id
            var ticket = _ticketManager.GetTicketById(ticketId);

            // if ticket not found
            if (ticket == null) return NotFound();

            // For now, I will just return a couple of tickets
            return Ok(ticket);
        }

        /// <summary>
        /// Gets the notes for a Ticket
        /// </summary>
        /// <param name="ticketId"></param>
        /// <returns>a list of Notes that are connected to the ticket.</returns>
        [HttpGet("{ticketId:int:min(1)}/notes")]
        public IActionResult GetNotesByTicketId(int ticketId)
        {
            //TODO Unit Tests

            // Log that method was called
            _logger.LogInformation($"{nameof(TicketsController)}.{nameof(GetNotesByTicketId)} called");

            // Get the notes by the ticket Id
            var notes = _noteManager.GetNotesByTicketId(ticketId);

            // if ticket not found
            if (notes == null) return NotFound();

            // For now, I will just return a couple of tickets
            return Ok(notes);
        }

        /// <summary>
        /// Get a List of Tickets for a specific person, for example used in "My Tickets"
        /// </summary>
        /// <param name="personId">The Id of the person</param>
        /// <returns>a list of notes for the person or NotFound when the person doesn't have any tickets</returns>
        [HttpGet("person/{personId:int:min(1)}")]
        public IActionResult GetTicketByPersonId(int personId) //TODO Would be better if this was a Guid, so no one can guess someone else's Id!
        {
            //TODO Unit Tests

            // Log that method was called
            _logger.LogInformation($"{nameof(TicketsController)}.{nameof(GetTicketByPersonId)} called");

            // Get the ticket by the Id
            var ticketsForPerson = _ticketManager.GetTicketByPersonId(personId);

            // if not found
            if (ticketsForPerson == null) return NotFound();

            // For now, return the persons tickets
            return Ok(ticketsForPerson);
        }

        /// <summary>
        /// Create or update a ticket
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns>true if update or create was successful, false if an error occured</returns>
        [HttpPut, HttpPost]
        public IActionResult CreateOrUpdateTicket(Ticket ticket)
        {
            //TODO Unit Tests

            // Log that method was called
            _logger.LogInformation($"{nameof(TicketsController)}.{nameof(CreateOrUpdateTicket)} called");

            // Note:
            // This method will be able to create a ticket, or update an existing ticket. 
            // In simple scenario's I think its fine to combine these two functions into one. 
            // However, as soon as there is a difference in how create and update are handled, I would separate them into two different methods. 

            // check Ticket
            if (ticket == null) return BadRequest("Please provide a ticket");

            // User manager to Create or update ticket
            var result = _ticketManager.CreateOrUpdateTicket(ticket);

            // Note:
            // I would probably use a generic result object for Create and Update methods, see note in manager.

            // return result. 
            return Ok(result);
        }

        /// <summary>
        /// Delete a ticket
        /// </summary>
        /// <param name="ticketId">Id of the ticket to delete</param>
        /// <param name="person">Person who is deleting the ticket</param>
        /// <returns>true if update or create was successful, false if an error occured</returns>
        [HttpDelete("{ticketId:int:min(1)}")]
        public IActionResult DeleteTicket(int ticketId, [FromBody] Person person)
        {

            //TODO Unit Tests

            // Log that method was called
            _logger.LogInformation($"{nameof(TicketsController)}.{nameof(DeleteTicket)} called");

            // Note, I included the Person in this Method, because I would want to know who deleted the ticket. (and check if user is allowed to)
            // probably also I would store a timestamp when it was deleted. 
            // (I would recommend a soft delete instead of a hard one.)
            // 
            // I would also like to note that I would either implement temporal tables (if MsSql server was used) 
            // Or have some way of each database object showing when it was last changed and by who. 
            // This would require information about the User to be known, in which case, the person parameter would not be needed. 

            // Check person
            if (person == null) return BadRequest("Please provide the person object when deleting a ticket");

            var result = _ticketManager.DeleteTicket(ticketId, person);

            // return result
            return Ok(result);
        }



    }
}
