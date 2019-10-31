using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace portal.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            ViewData["MyNumber"] = 42;
            ViewData["MyString"] = "Hello World";
            ViewData["MyComplexObject"] = new Book
            {
                Title = "Sum Of All Fears",
                Author = new Author { Name = "Tom Clancy" },
                Price = 5.99m
            };
        }
    }

    internal class Author
    {
        public string Name { get; set; }
    }

    internal class Book
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public decimal Price { get; set; }
    }
}
