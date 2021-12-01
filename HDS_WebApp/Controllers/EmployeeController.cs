using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDS_WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult EmployeeIndex()
        {
            return View();
        }
    }
}
