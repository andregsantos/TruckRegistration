using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TruckRegistration.Data;
using TruckRegistration.Data.Entity;
using TruckRegistration.Models;

namespace TruckRegistration.Controllers
{
    public class TruckController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TruckController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trucks
        public async Task<IActionResult> Index()
        {
            var trucks = _context.Trucks
                .AsNoTracking();

            return View(await trucks.ToListAsync());
        }

        // GET: Trucks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truck = await _context.Trucks
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (truck == null)
            {
                return NotFound();
            }

            PopulateAssignedModelData();
            return View(truck);
        }

        // GET: Trucks/Create
        public IActionResult Create()
        {
            PopulateAssignedModelData();
            return View();
        }

        // POST: Trucks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,YearOfModel,Year")] Truck truck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(truck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopulateAssignedModelData();
            return View();
        }

        // POST: Trucks/Create
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Model,YearOfModel,Year")] Truck truck)
        {
            if (ModelState.IsValid)
            {
                _context.Update(truck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopulateAssignedModelData();
            return View(truck);
        }

        // GET: Trucks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truck = await _context.Trucks
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (truck == null)
            {
                return NotFound();
            }

            PopulateAssignedModelData();
            return View(truck);
        }

        // GET: Trucks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truck = await _context.Trucks
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (truck == null)
            {
                return NotFound();
            }

            return View(truck);
        }

        // POST: Trucks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var truck = await _context.Trucks.FindAsync(id);
            _context.Trucks.Remove(truck);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TruckExists(int id)
        {
            return _context.Trucks.Any(e => e.Id == id);
        }

        private void PopulateAssignedModelData()
        {
            var modelViewModel = new List<ModelViewModel>()
            {
                new ModelViewModel(){ Model = "FH"},
                new ModelViewModel(){ Model = "FM"},
            };

            ViewData["Model"] = new SelectList(modelViewModel, "Model", "Model");
        }
    }
}
