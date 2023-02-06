using HW20.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HW20.Controllers
{
    public class HomeController : Controller
    {
        private readonly NoteDbContext noteDbContext;

        public HomeController(NoteDbContext noteDbContext)
        {
            this.noteDbContext = noteDbContext;
        }

        public IActionResult Index()
        {
            var notes = noteDbContext.Notes.ToList();
            return View(notes);
        }

        public IActionResult FullNote(int id)
        {
            var notes = noteDbContext.Notes.ToList();
            var note = notes.SingleOrDefault(_note => _note.Id == id);

            if (note == null)
            {
                return RedirectToAction("Index");
            }

            return View(note);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}