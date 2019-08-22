using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealingHandsMassage.Data;
using HealingHandsMassage.Models;

namespace HealingHandsMassage.Controllers
{
    public class CarouselItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarouselItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CarouselItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarouselItems.ToListAsync());
        }

        // GET: CarouselItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carouselItem = await _context.CarouselItems
                .FirstOrDefaultAsync(m => m.id == id);
            if (carouselItem == null)
            {
                return NotFound();
            }

            return View(carouselItem);
        }

        // GET: CarouselItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarouselItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,ImagePath,TextInJson")] CarouselItem carouselItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carouselItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carouselItem);
        }

        // GET: CarouselItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carouselItem = await _context.CarouselItems.FindAsync(id);
            if (carouselItem == null)
            {
                return NotFound();
            }
            return View(carouselItem);
        }

        // POST: CarouselItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,ImagePath,TextInJson")] CarouselItem carouselItem)
        {
            if (id != carouselItem.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carouselItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarouselItemExists(carouselItem.id))
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
            return View(carouselItem);
        }

        // GET: CarouselItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carouselItem = await _context.CarouselItems
                .FirstOrDefaultAsync(m => m.id == id);
            if (carouselItem == null)
            {
                return NotFound();
            }

            return View(carouselItem);
        }

        // POST: CarouselItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carouselItem = await _context.CarouselItems.FindAsync(id);
            _context.CarouselItems.Remove(carouselItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarouselItemExists(int id)
        {
            return _context.CarouselItems.Any(e => e.id == id);
        }
    }
}
