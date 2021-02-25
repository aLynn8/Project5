using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project5.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Project5.Models.ViewModels;

//Aubrey Farnbach (Wright) Section 2 Group 1

namespace Project5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBookRepository _repository;

        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IBookRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(int page = 1)
        {
            //Passes in book data from database
            //query in Linq
            return View(new ProjectListViewModel
                {
                    Books = _repository.Books
                        .OrderBy(p => p.Title)
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize)
                        ,
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalNumItems = _repository.Books.Count()
                    }
            });

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
