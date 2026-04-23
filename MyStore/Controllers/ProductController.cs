using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyStore.Models;
using MyStore.Repositories;

public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ProductController(
        IProductRepository productRepository,
        ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    // ===== ADD (GET) =====
public IActionResult Add()
{
    // Lấy danh sách danh mục từ Repository
    var categories = _categoryRepository.GetAllCategories();
    
    // Chuyển danh sách sang SelectList để hiển thị trong dropdown (select)
    ViewBag.Categories = new SelectList(categories, "Id", "Name");
    
    return View();
}

// ===== ADD (POST) =====
[HttpPost]
public IActionResult Add(Product product)
{
    if (ModelState.IsValid)
    {
        _productRepository.Add(product);
        return RedirectToAction("Index");
    }
    
    // Nếu dữ liệu không hợp lệ, cần nạp lại danh sách Categories trước khi trả về View
    var categories = _categoryRepository.GetAllCategories();
    ViewBag.Categories = new SelectList(categories, "Id", "Name");
    
    return View(product);
}
    // ===== DISPLAY =====
    public IActionResult Display(int id)
    {
        var product = _productRepository.GetById(id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // ===== UPDATE (GET) =====
    public IActionResult Update(int id)
    {
        var product = _productRepository.GetById(id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // ===== UPDATE (POST) =====
    [HttpPost]
    public IActionResult Update(Product product)
    {
        if (ModelState.IsValid)
        {
            _productRepository.Update(product);
            return RedirectToAction("Index");
        }

        return View(product);
    }

    // ===== DELETE (GET) =====
    public IActionResult Delete(int id)
    {
        var product = _productRepository.GetById(id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // ===== DELETE (POST) =====
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        _productRepository.Delete(id);
        return RedirectToAction("Index");
    }
}