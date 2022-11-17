using AutoMapper;
using GSC_API.DataAccess;
using GSC_API.Dto;
using GSC_API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GSC_API.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(CategoryRepository categoryRepository, IMapper mapper) {
            _categoryRepository = categoryRepository;
            _mapper = mapper;

        }
        public IActionResult Index()
        {
            var category = _categoryRepository.GetAll();
            return View(category);
        }
        public IActionResult Create() //Que raro que es este controller verdad?
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryDTO category)
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

            var category = _categoryRepository.GetById(id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost] 
        [ValidateAntiForgeryToken] //Junto con el form TAG nos ayudan a prevenir XSRF/CSRF.
        public IActionResult Edit(int id, Category entity)
        {
            if (id != entity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _categoryRepository.Update(entity);

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

            var category = _categoryRepository.GetById(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            ViewBag.AsignadoEnDetails = "Este string lo asigne en el action Details del controller";

            return View(category);
        }
    
        public  IActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var category = _categoryRepository.GetById(id);
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
