using AutoMapper;
using GSC_API.DataAccess;
using GSC_API.Dto;
using GSC_API.Entities;
using GSC_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GSC_API.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper) {
            _categoryRepository = categoryRepository;
            _mapper = mapper;

        }
        public IActionResult Index()
        {
            var category = _categoryRepository.GetAll();
           List<CategoryViewModel> categoryviewmodel = _mapper.Map<List<CategoryViewModel>>(category);
            return View(categoryviewmodel);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryViewModel category)
        {
            if (!ModelState.IsValid)
                return View("Create", category);

            var entity = _categoryRepository.Add(category);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _mapper.Map<CategoryViewModel>(_categoryRepository.GetById(id.Value));
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost] 
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CategoryViewModel entity)
        {
            if (id != entity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(entity);
                _categoryRepository.Update(category);

                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _mapper.Map<CategoryViewModel>(_categoryRepository.GetById(id.Value));
            if (category == null)
            {
                return NotFound();
            }

            ViewBag.AsignadoEnDetails = "Este string lo asigne en el action Details del controller";

            return View(category);
        }
    
        public  IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var category = _mapper.Map<CategoryViewModel>(_categoryRepository.GetById(id));
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category is null)
            {
                return NotFound();
            }

            _categoryRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
