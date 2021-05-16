using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class CategoryTblsController : Controller
    {
        private readonly ShoppingCartDBContext _context;

        public CategoryTblsController(ShoppingCartDBContext context)
        {
            _context = context;
        }

        // GET: CategoryTbls
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.CategoryTbls.ToListAsync());
        //}

        //List by Given Category
        [Route("Kategori/{categoryName?}")]
        public async Task<IActionResult> Index(string categoryName)
        {
            //await Component.InvokeAsync("Products");
            //var a = HttpUtility.HtmlDecode(categoryName);
            var categoryNameR = categoryName.Replace("-", " ");
            var categoryRecord = _context.CategoryTbls.Where(y => y.Name == categoryNameR).FirstOrDefault();
            if (categoryRecord != null)
            {
                //var Plist = _context.ProductTbls.Where(x => x.CategoryId == categoryRecord.Id).ToList();
                return ViewComponent("Products", new { categoryName});
                //return View("../ProductTbls/Index");
            }
            return View();


            
            //return View(await _context.CategoryTbls.Where(x => x.Name == categoryName).ToListAsync());
        }

        // GET: CategoryTbls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryTbl = await _context.CategoryTbls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryTbl == null)
            {
                return NotFound();
            }

            return View(categoryTbl);
        }

        // GET: CategoryTbls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Photo")] CategoryTbl categoryTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryTbl);
        }

        // GET: CategoryTbls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryTbl = await _context.CategoryTbls.FindAsync(id);
            if (categoryTbl == null)
            {
                return NotFound();
            }
            return View(categoryTbl);
        }

        // POST: CategoryTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Photo")] CategoryTbl categoryTbl)
        {
            if (id != categoryTbl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryTblExists(categoryTbl.Id))
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
            return View(categoryTbl);
        }

        // GET: CategoryTbls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryTbl = await _context.CategoryTbls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryTbl == null)
            {
                return NotFound();
            }

            return View(categoryTbl);
        }

        // POST: CategoryTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryTbl = await _context.CategoryTbls.FindAsync(id);
            _context.CategoryTbls.Remove(categoryTbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryTblExists(int id)
        {
            return _context.CategoryTbls.Any(e => e.Id == id);
        }
    }
}
