using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Models;

namespace UIWebApp.Controllers
{
    public class ProductsStoresController : Controller
    {
        private readonly ProductContext _context;

        public ProductsStoresController(ProductContext context)
        {
            _context = context;
        }

        // GET: ProductsStores
        public async Task<IActionResult> Index()
        {
            var productContext = _context.ProductsStores.Include(p => p.Product).Include(p => p.Store);
            return View(await productContext.ToListAsync());
        }

        // GET: ProductsStores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productStore = await _context.ProductsStores
                .Include(p => p.Product)
                .Include(p => p.Store)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productStore == null)
            {
                return NotFound();
            }

            return View(productStore);
        }

        // GET: ProductsStores/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Name");
            return View();
        }

        // POST: ProductsStores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,StoreId,Stock")] ProductStore productStore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productStore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", productStore.ProductId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Name", productStore.StoreId);
            return View(productStore);
        }

        // GET: ProductsStores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productStore = await _context.ProductsStores.FindAsync(id);
            if (productStore == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", productStore.ProductId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Name", productStore.StoreId);
            return View(productStore);
        }

        // POST: ProductsStores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,StoreId,Stock")] ProductStore productStore)
        {
            if (id != productStore.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productStore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductStoreExists(productStore.ProductId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", productStore.ProductId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Name", productStore.StoreId);
            return View(productStore);
        }

        // GET: ProductsStores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productStore = await _context.ProductsStores
                .Include(p => p.Product)
                .Include(p => p.Store)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productStore == null)
            {
                return NotFound();
            }

            return View(productStore);
        }

        // POST: ProductsStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productStore = await _context.ProductsStores.FindAsync(id);
            _context.ProductsStores.Remove(productStore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductStoreExists(int id)
        {
            return _context.ProductsStores.Any(e => e.ProductId == id);
        }
    }
}
