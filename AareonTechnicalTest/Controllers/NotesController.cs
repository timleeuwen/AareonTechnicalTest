using AareonTechnicalTest.Managers;
using AareonTechnicalTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AareonTechnicalTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly ILogger<NotesController> _logger;
        private readonly INoteManager _noteManager;

        public NotesController(ILogger<NotesController> logger, INoteManager noteManager)
        {
            _logger = logger;
            _noteManager = noteManager;
        }
        
        /// <summary>
        /// Create Or Update a Note
        /// </summary>
        /// <param name="note">The note to create or update</param>
        /// <returns></returns>
        [HttpPut, HttpPost]
        public IActionResult CreateOrUpdateNote(Note note)
        {
            //TODO Unit Tests

            // Log that method was called
            _logger.LogInformation($"{nameof(NotesController)}.{nameof(CreateOrUpdateNote)} called");

            // Note:
            // This method will be able to create a note, or update an existing note. 
            // In simple scenario's I think its fine to combine these two functions into one. 
            // However, as soon as there is a difference in how create and update are handled, I would separate them into two different methods. 

            // check note
            if (note == null) return BadRequest("Please provide a note");

            // User manager to Create or update note
            var result = _noteManager.CreateOrUpdateNote(note);

            // Note:
            // I would probably use a generic result object for Create and Update methods, see note in manager.

            // return result. 
            return Ok(result);
        }

        /// <summary>
        /// Remove a note
        /// </summary>
        /// <param name="noteId">Note Id to be removed</param>
        /// <param name="person">Person who is removing the note</param>
        /// <returns>A value true or false indicating the success</returns>
        [HttpPut("remove/{noteId:int:min(1)}")]
        public IActionResult RemoveNote(int noteId, [FromBody] Person person)
        {
            //TODO Unit Tests

            // Log that method was called
            _logger.LogInformation($"{nameof(NotesController)}.{nameof(RemoveNote)} called");

            // Check person
            if (person == null) return BadRequest("Please provide the person object when deleting a note");
            var result = _noteManager.RemoveNote(noteId, person);

            // return result
            return Ok(result);

        }
        
        /// <summary>
        /// Deletes a note
        /// </summary>
        /// <param name="noteId">Note Id to delete</param>
        /// <param name="person">Person who is doing the delete</param>
        /// <returns>A value true or false indicating the success</returns>
        [HttpDelete("{noteId:int:min(1)}")]
        public IActionResult DeleteNote(int noteId, [FromBody] Person person)
        {
            //TODO Unit Tests

            // Log that method was called
            _logger.LogInformation($"{nameof(NotesController)}.{nameof(DeleteNote)} called");

            // Check person
            if (person == null) return BadRequest("Please provide the person object when deleting a note");

            // Note, I included the Person in this Method, because I would want to know who deleted the note and if user is allowed to
            // probably also I would store a timestamp when it was deleted. 
            // (I would recommend a soft delete instead of a hard one.)
            // 
            // I would also like to note that I would either implement temporal tables (if MsSql server was used) 
            // Or have some way of each database object showing when it was last changed and by who. 
            // This would require information about the User to be known, in which case, the person parameter would not be needed. 

            var result = _noteManager.DeleteNote(noteId, person);

            // return result
            return Ok(result);
        }
    }
}
