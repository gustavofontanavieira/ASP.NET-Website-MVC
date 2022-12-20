using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyMVCSite.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyMVCSite.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            HomeModel home = new HomeModel();

            home.Nome = "Gustavo";
            home.Email = "gustavoacvvvieira@outlook.com";

            return View(home);//vai conseguir interagir com os dados setados acima
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
