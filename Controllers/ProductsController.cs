using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BulkyWeb.Data;
using BulkyWeb.Models;
using BulkyWeb.Services;
using BulkyWeb.ViewModels.Products;
using Microsoft.AspNetCore.Authorization;

namespace BulkyWeb.Controllers
{
    [Authorize(Roles = RoleName.Administrator)]

    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        int a = 8;
        private readonly IProductService _productService;
        public ProductsController(ApplicationDbContext context , IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        // GET: Products
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {

            ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) || sortOrder.Equals("title") ? "title_desc" : "";
            ViewData["AuthorSortParm"] = String.IsNullOrEmpty(sortOrder) || sortOrder.Equals("author") ? "author" : "";
            ViewData["ListPriceSortParm"] = String.IsNullOrEmpty(sortOrder) || sortOrder.Equals("listprice") ? "listprice" : "";

            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;
            // var applicationDbContext = _context.Products.Include(p => p.Category);
            return View(await _productService.GetAllFilter(sortOrder, currentFilter, searchString, pageNumber, a));
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetProduct(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categorys, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.Create(request);
                if (result != null)
                    return RedirectToAction(nameof(Index));

            }
            ViewData["CategoryId"] = new SelectList(_context.Categorys, "Id", "Name", request.CategoryId);
            return View(request);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetProduct(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categorys, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductViewModel product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _productService.Update(id, product);
                    if (result)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                ViewData["CategoryId"] = new SelectList(_context.Categorys, "Id", "Name", product.CategoryId);
                return RedirectToAction(nameof(Index));

            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetProduct(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
