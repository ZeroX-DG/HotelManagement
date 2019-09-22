using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Data;
using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class ContactController : Controller
    {

        private readonly ApplicationDbContext _dbContext;
        public ContactController(ApplicationDbContext context)
        {
            _dbContext = context;

        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Contact model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Contacts.Add(model);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("ContactComplete");
            }
            return View(model);
        }

        public IActionResult ContactComplete()
        {
            ViewBag.ContactCompleteMessageLine1 = "Your message has been sent.";
            ViewBag.ContactCompleteMessageLine2 = "We will contact you soon ! :)";

            return View();
        }
    }
}