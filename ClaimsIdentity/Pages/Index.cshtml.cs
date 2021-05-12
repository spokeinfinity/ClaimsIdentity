using Apka_NET.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ClaimsIdentity.Data;


namespace Apka_NET.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _context;
        private readonly ILogger<IndexModel> _logger;
    

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [BindProperty]
        public Address Address { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        public async Task <IActionResult> OnPost()
        {
                int number;
                if (Int32.TryParse(Address.NumberString, out number))
                {
                    Address.Number = number;
                    if (Address.Number >= 1 && Address.Number <= 1000)
                    {
                        if(Address.Number %3 ==0 && Address.Number %5 !=0)
                        {
                            Address.Napis = "Fizz";
                        }
                        else if (Address.Number % 5 == 0 && Address.Number % 3 != 0)
                        {
                            Address.Napis = "Buzz";
                        }
                        else if (Address.Number % 3 == 0 && Address.Number % 5 == 0)
                        {
                            Address.Napis = "FizzBuzz";
                        }
                        else
                        {
                            Address.Napis = "Żadna";
                        }
                        Address.SystemTime = DateTime.Now;
                        HttpContext.Session.SetString("SessionAddress", JsonConvert.SerializeObject(Address));
                    if (ModelState.IsValid)
                    {
                        await _context.Address.AddAsync(Address);
                        await _context.SaveChangesAsync();
                        return Page();
                    }
                    }
                    else
                    {
                        Address.Napis = "Błąd";
                    }


                }
                else
                {
                    Address.Napis = "Błąd";
                }
            
            return Page();
        }

        public void OnGet()
        {
         /*   if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";

            }*/
        }
    }
}
