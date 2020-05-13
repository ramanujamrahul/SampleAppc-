using Microsoft.AspNetCore.Mvc;
using SampleApp.Services;
using SampleApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp.Controllers
{
    public class AppController : Controller
    {
        private readonly INullMailService _mailService;

        public AppController(INullMailService mailService)
        {
            this._mailService = mailService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailService.SendMessage("ab@gmail.com", model.Subject, $"From:{model.Name}, Message:{model.Message}");
                ViewBag.UserMessage = "Mail Sent";
            }

            return View();
        }
        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }
    }
}
