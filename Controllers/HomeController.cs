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

        public IActionResult Index(string category, int pageNum = 1)
        {
            //Passes in book data from database
            //query in Linq
            return View(new ProjectListViewModel
                {
                    Books = _repository.Books
                    .Where(p => category == null || p.ClassificationCategoryB == category)
                        .OrderBy(p => p.Title)
                        .Skip((pageNum - 1) * PageSize)
                        .Take(PageSize)
                        ,
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = pageNum,
                        ItemsPerPage = PageSize,
                        //Dynamically updates the nu,ber of pages based on the user's category selection

                        TotalNumItems = category == null ? _repository.Books.Count() :
                            _repository.Books.Where(x => x.ClassificationCategoryB == category).Count()
                    },
                    Type = category
            });

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
