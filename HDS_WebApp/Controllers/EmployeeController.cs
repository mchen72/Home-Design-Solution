using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HDS_WebApp.Data;
using HDS_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HDS_WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ProductDbContext _context; //context for data to send to view

        public EmployeeController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult EmployeeIndex()
        {
            return View();
        }
        public async Task<IActionResult> Inventory()
        {
            return View(await _context.ProductData.ToListAsync());
        }
    }
}
