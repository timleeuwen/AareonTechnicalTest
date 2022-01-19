using System.Collections.Generic;
using AareonTechnicalTest.Models;

namespace AareonTechnicalTest.Managers
{
    public interface INoteManager
    {
        IEnumerable<Note> GetNotesByTicketId(int ticketId);
        bool CreateOrUpdateNote(Note note);
        bool RemoveNote(int noteId, Person person);
        bool DeleteNote(int noteId, Person person);
    }
}
