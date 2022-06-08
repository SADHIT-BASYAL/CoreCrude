using Crudeoperation.DataAccessLayer;
using Crudeoperation.DataAccessLayer.Infrastructure.IRepository;
using Crudeoperation.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreCrude.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private IUnitOfWork unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = unitOfWork.Category.GetAll();
            return View(categories);
        }

        //create category
        [HttpGet]
        public IActionResult Create()
        {
            // IEnumerable<Category> categories = db.Categories;
            //return View(categories);
            return View();
        }

        //create category post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Category.Add(category);
                unitOfWork.Save();
                TempData["success"] = "category created done";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        //Edit

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var Category = unitOfWork.Category.GetT(x => x.Id == Id);
            if (Category == null)
            {
                return NotFound();
            }

            return View(Category);
        }

        //create category post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Category.Update(category);
                unitOfWork.Save();
                TempData["success"] = "category updated done";

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        //**************************** Delete ////////////////

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var Category = unitOfWork.Category.GetT(x => x.Id == Id);
            if (Category == null)
            {
                return NotFound();
            }

            return View(Category);
        }

        //create category post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? Id)
        {
            var Category = unitOfWork.Category.GetT(x => x.Id == Id);
            if (Category == null)
            {
                return NotFound();
            }
            unitOfWork.Category.Delete(Category);
            unitOfWork.Save();
            TempData["success"] = "category Delete done";

            return RedirectToAction("Index");
        }
    }
}