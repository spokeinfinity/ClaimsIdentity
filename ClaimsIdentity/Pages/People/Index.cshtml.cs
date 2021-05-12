using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClaimsIdentity.Data;
using Apka_NET.Models;
using Microsoft.AspNetCore.Authorization;

namespace Apka_NET.Pages.People
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Address> Address { get;set; }
        public void OnGet()
        {
            Address = _context.Address.OrderByDescending(u => u.SystemTime).Take(20).ToList();
        }

        /*   public async Task OnGetAsync()
           {
               Address = await _context.Address.ToListAsync();
           }*/
    }
}
