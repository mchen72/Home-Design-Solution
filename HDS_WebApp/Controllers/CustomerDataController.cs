using HDS_WebApp.Data;
using HDS_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HDS_WebApp.Controllers
{
    public class CustomerDataController : Controller
    {
        private readonly CustomerDbContext _context;

        public CustomerDataController(CustomerDbContext context)
        {
            _context = context;
        }

        // GET: CustomerData
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerData.ToListAsync());
        }

        // GET: CustomerData/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerData = await _context.CustomerData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerData == null)
            {
                return NotFound();
            }

            return View(customerData);
        }

        // GET: CustomerData/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LastName,FirstName,StreetAddress,City,State,ZipCode,Id,PhoneNumber")] CustomerData customerData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerData);
        }

        // GET: CustomerData/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerData = await _context.CustomerData.FindAsync(id);
            if (customerData == null)
            {
                return NotFound();
            }
            return View(customerData);
        }

        // POST: CustomerData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LastName,FirstName,StreetAddress,City,State,ZipCode,Id,PhoneNumber")] CustomerData customerData)
        {
            if (id != customerData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerDataExists(customerData.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customerData);
        }

        // GET: CustomerData/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerData = await _context.CustomerData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerData == null)
            {
                return NotFound();
            }

            return View(customerData);
        }

        // POST: CustomerData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var customerData = await _context.CustomerData.FindAsync(id);
            _context.CustomerData.Remove(customerData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerDataExists(string id)
        {
            return _context.CustomerData.Any(e => e.Id == id);
        }
    }
}
