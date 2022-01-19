using System;
using System.Collections.Generic;
using AareonTechnicalTest.Models;

namespace AareonTechnicalTest.Managers
{
    public class NoteManager: INoteManager
    {
        public IEnumerable<Note> GetNotesByTicketId(int ticketId)
        {
            //TODO Get all Notes for Ticket, order them by the Timestamp so the last note is at the bottom

            //TODO Find a way to add the person name to the note, possibly have to create a viewmodel that contains the name of the person that made the note.
            
            //TODO for now return empty list
            return new List<Note>();
        }

        public bool CreateOrUpdateNote(Note note)
        {
            // Check note 
            if (note == null) throw new ArgumentNullException();

            // TODO check if note has an ID of 0, if it does, CREATE a note 
            // TODO if there is a value > 0 for ticket, then UPDATE the ticket

            // If Create or Update was succesfull, return true, else return false
            return true;

            // NOTE:
            // I would probably create a generic return object that would either give back the Id of the newly created object
            // Or the Id of the updated object, plus a status of Success or Failure.
            // If the Create/Update failed for some reason, I would also return a message with the return object that describes why it failed.
        }

        public bool RemoveNote(int noteId, Person person)
        {
            // TODO Handle logic to remove Note. which means, the note is not deleted, but is marked as removed.

            return true;
        }

        public bool DeleteNote(int noteId, Person person)
        {
            // TODO Handle logic to DELETE the Note. which means, the note is actually deleted. 
            // TODO this will also check if the user is alowed to do the actual delete first! 
            
            return true;
        }
    }
}
