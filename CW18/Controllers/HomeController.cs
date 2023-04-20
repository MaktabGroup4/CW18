using CW18.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Test;
using System.Diagnostics;

namespace CW18.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositoryMethods _repository;

        public HomeController(ILogger<HomeController> logger, IRepositoryMethods repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Members()
        {
            var model = _repository.GetMembers();
            return View(model);
        }

        public IActionResult MembersBooks()
        {
            var model = _repository.GetMembersBooks();
            return View(model);
        }

        public IActionResult BorrowedInState()
        {
            var model = _repository.BorrowedInState();
            return View(model);
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