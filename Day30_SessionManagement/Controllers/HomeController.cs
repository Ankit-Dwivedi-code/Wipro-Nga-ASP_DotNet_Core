using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Day30_SessionManagement.Models;

namespace Day30_SessionManagement.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        int visitCount = HttpContext.Session.GetInt32("VisitCount") ?? 0;
        // using ?? 0 to provide a default value  this operator is called the null-coalescing operator
        visitCount++; // increse the count by 1
        HttpContext.Session.SetInt32("VisitCount", visitCount); //storing the new count to session
        //passing the count to the view
        return View(visitCount);
        //if we dont want to pass the count to the view, we can simply return the view without any parameters
        // using  inbuilt Key value pair variables are ViewData and ViewBag
        //both ViewData and ViewBag can be used to pass data from controller to view
        
        // ViewData is a dictionary object and ViewBag is a dynamic object
        // ViewData["VisitCount"] = visitCount; // key value pair
        // or
        // ViewBag.VisitCount = visitCount; // dynamic object using properties
        // View State which was prominent in earlier version of ASP.NET web app

    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

     public IActionResult Reset() // resetting the session
    {
        //HttpContext.Session.Clear(); // Clear all session data
        HttpContext.Session.Remove("VisitCount"); // Remove specific session variable
        
        return RedirectToAction("Index"); // Redirect to Index action
        //We have other ways also to redirect/ transfer server session server.transfer()
    }

}
