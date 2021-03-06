using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;

using Microsoft.AspNetCore.Http;
using System.Globalization;
using SampleFive.ServiceLayer.Interfaces;

namespace SampleFive.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly ISettingService _messagesService;
        public HomeController(ISettingService messagesService)
        {
            _messagesService = messagesService;
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        public IActionResult About()
        {
            return new ContentResult
            {
                Content = "Hello my King!",
                ContentType = "text/plain; charset=utf-8"
            };
        }

        public IActionResult IndexWithView()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}