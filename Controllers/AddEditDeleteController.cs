using HW20.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW20.Controllers
{
    public class AddEditDeleteController : Controller
    {
        private readonly NoteDbContext noteDbContext;

        public AddEditDeleteController(NoteDbContext noteDbContext)
        {
            this.noteDbContext = noteDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Note note)
        {
            if (ModelState.IsValid)
            {
                noteDbContext.Notes.Add(note);
                noteDbContext.SaveChanges();
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var note = noteDbContext.Notes.SingleOrDefault(x => x.Id == id);

            if (note == null)
            {
                return RedirectToAction("Index");
            }

            return View("Edit", note);
        }

        [HttpPost]
        public IActionResult Update(Note note)
        {
            if (ModelState.IsValid)
            {
                noteDbContext.Notes.Update(note);
                noteDbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction(nameof(Add), new { id = note.Id });
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var note = noteDbContext.Notes.SingleOrDefault(x => x.Id == id);

            if(note == null)
            {
                return NotFound();
            }
            
            noteDbContext.Remove(note);
            noteDbContext.SaveChanges();
            
            return RedirectToAction("Index", "Home");
        }
    }
}
