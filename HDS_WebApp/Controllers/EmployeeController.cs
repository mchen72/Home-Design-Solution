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
        private readonly ProductDbContext p_context; //context for data to send to view

        public EmployeeController(ProductDbContext context)
        {
            p_context = context;
        }

        public IActionResult EmployeeIndex()
        {
            return View();
        }
        public async Task<IActionResult> Inventory()
        {
            return View(await p_context.ProductData.ToListAsync());
        }

    }
}
