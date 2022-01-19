using System;
using System.Collections.Generic;
using System.Linq;
using AareonTechnicalTest.Models;

namespace AareonTechnicalTest.Managers
{
    // TODO write unit tests for this manager

    public class TicketManager: ITicketManager
    {
        private List<Ticket> getTestTickets()
        {
            var tickets = new List<Ticket>
            {
                new Ticket {Content = "Ticket 1", PersonId = 1},
                new Ticket {Content = "Ticket 2", PersonId = 1},
                new Ticket {Content = "Ticket 3", PersonId = 2},
                new Ticket {Content = "Ticket 4", PersonId = 2},

            };

            return tickets;
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return getTestTickets();
        }

        public Ticket GetTicketById(int ticketId)
        {
            // Check parameter
            if (ticketId <= 0) return null;

            // Get all Tickets TODO Get tickets from database
            var tickets = getTestTickets();

            // Return the ticket
            return tickets.FirstOrDefault(s => s.Id == ticketId);
        }

        public IEnumerable<Ticket> GetTicketByPersonId(int personId)
        {
            // Check parameter
            if (personId <= 0) return null;

            // Get all Tickets TODO Get tickets from database
            var tickets = getTestTickets();

            // Return the ticket
            return tickets.Where(s => s.PersonId == personId);
        }

        public bool CreateOrUpdateTicket(Ticket ticket)
        {
            // Check ticket 
            if(ticket == null) throw new ArgumentNullException();

            // TODO check if ticket has an ID of 0, if it does, CREATE a ticket 
            // TODO if there is a value > 0 for ticket, then UPDATE the ticket

            // If Create or Update was successful, return true, else return false
            return true;

            // NOTE:
            // I would probably create a generic return object that would either give back the Id of the newly created object
            // Or the Id of the updated object, plus a status of Success or Failure.
            // If the Create/Update failed for some reason, I would also return a message with the return object that describes why it failed.

        }

        public bool DeleteTicket(int ticketId, Person person)
        {
            // Check parameters
            if (ticketId <= 0) return false;
            if (person == null) return false;

            //TODO Check if Person is Admin to delete Ticket?? 
            
            // Note:
            // I think that this should perhaps do a soft delete, so the Ticket object would need to have a flag "deleted" so that 
            // tickets are not actually deleted? Unless the specifications actually require this...
            // If using a soft delete, we could reuse the update function above and return the result from that, 
            
            // I am assuming that the (soft) delete action succeeded, however the delete could fail, in that case return false, 
            // Or perhaps a generic return object, with the reason why it failed.
            return true;
        }
    }
}
