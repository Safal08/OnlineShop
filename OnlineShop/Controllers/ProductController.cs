using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Domain;
using OnlineShop.Services;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            return View( await _productService.GetAllProducts());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _productService.GetProductById(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _productService.CreateProductAsync(product);
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _productService.GetProductById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dbProduct = await _productService.GetProductById(id);
                    if (await TryUpdateModelAsync<Product>(dbProduct))
                    {
                        await _productService.UpdateProductAsync(dbProduct);
                        return RedirectToAction(nameof(Index));
                    }
                    await _productService.UpdateProductAsync(product);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var dbProduct = await _productService.GetProductById(id);
                if (dbProduct != null)
                {
                    await _productService.DeletePropertyAsync(dbProduct);
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Unable to delete. ");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
