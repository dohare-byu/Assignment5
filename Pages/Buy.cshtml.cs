using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment5.Infastructure;
using Assignment5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment5.Pages
{
    public class BuyModel : PageModel
    {
        private IAssignment5Repository repository;

        public BuyModel(IAssignment5Repository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(long ID, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(p => p.ID == ID);

            Cart.AddItem(book, 1);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove (long ID, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
            cl.Book.ID == ID).Book);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
