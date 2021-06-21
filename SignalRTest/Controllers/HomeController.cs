using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignalRTest.Data;
using SignalRTest.Models;
using SignalRTest.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRTest.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public readonly ILogger<HomeController> _logger;
        public readonly IChat _IChat;
        public readonly UserManager<AppUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager,IChat chat)
        {
            _logger = logger;
            _userManager = userManager;
            _IChat = chat;
        }

        public async Task<IActionResult> Index()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.CurrentUserName = CurrentUser.UserName;
            }
            var Messages = _IChat.GetMessageses();
            return View(Messages);

        }
        [HttpPost]
        public async Task<IActionResult> Create(Message message)
        {
            //if (ModelState.IsValid)
            //{
                message.UserName = User.Identity.Name;
                var Sender = await _userManager.GetUserAsync(User);
                message.UserId = Sender.Id;
                await _IChat.AddMessage(message);
                return Ok();

            //}
            //return Error();
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
    }
}
