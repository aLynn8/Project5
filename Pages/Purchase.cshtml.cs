using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project5.Infrastructure;
using Project5.Models;

//Aubrey Farnbach (Wright) Section 2 Group 1


namespace Project5.Pages
{
    //Sets repository equal to the repo that was passed in
    public class PurchaseModel : PageModel
    {
        private IBookRepository repository;

        //Constructor
        public PurchaseModel (IBookRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        //Properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        //Methods
        public void OnGet(string returnUrl)
        {
            //Set to what was passed in or a slash
            ReturnUrl = ReturnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(string isbn, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(b => b.Isbn == isbn);

            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(book, 1);

            //HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        //Remove an item
        public IActionResult OnPostRemove(string isbn, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Book.Isbn == isbn).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
