using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PluralsightPieCourse.Models;
using PluralsightPieCourse.ViewModels;

namespace PluralsightPieCourse.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        // Constructor injection! See the startup file to see where the repo is coming from
        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PiesOfTheWeek = _pieRepository.PiesOfTheWeek
            };

            return View(homeViewModel);
        }
    }
}
