using Microsoft.AspNetCore.Mvc;
using Day28_FeedbackPortal.Models;

namespace Day28_FeedbackPortal.Controllers
{
    public class FeedbackController : Controller
    {
        // temporary in-memory storage
        private static List<Feedback> feedbackList = new List<Feedback>();

        // GET: Feedback/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Feedback/Create
        [HttpPost]
        public IActionResult Create(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedbackList.Add(feedback);
                return RedirectToAction("List");
            }
            return View(feedback);
        }

        // GET: Feedback/List
        public IActionResult List()
        {
            return View(feedbackList);
        }
    }
}
