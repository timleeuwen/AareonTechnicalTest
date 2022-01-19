using System.Collections.Generic;
using AareonTechnicalTest.Models;

namespace AareonTechnicalTest.Managers
{
    public interface ITicketManager
    {
        IEnumerable<Ticket> GetAllTickets();
        Ticket GetTicketById(int ticketId);
        IEnumerable<Ticket> GetTicketByPersonId(int personId);

        // Note instead of bool I think it would be better to have a generic return object that indicates success or failure, perhaps with the Id of the changed/created object.

        bool CreateOrUpdateTicket(Ticket ticket);
        bool DeleteTicket(int ticketId, Person person);
    }
}
