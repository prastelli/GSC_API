using AutoMapper;
using GSC_API.DataAccess;
using GSC_API.Entities;
using GSC_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GSC_API.Controllers
{
    public class ThingController : Controller
    {
        private readonly IThingRepository _thingRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public ThingController(IThingRepository thingRepository, IMapper mapper,ICategoryRepository categoryRepository)
        {
            _thingRepository = thingRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var category = _thingRepository.GetAll();
            List<ThingsViewModel> thingviewmodel = _mapper.Map<List<ThingsViewModel>>(category);
            return View(thingviewmodel);
            
        }
        public IActionResult Create() //Que raro que es este controller verdad?
        {
            ViewBag.categories = _categoryRepository.GetListItems();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ThingsViewModel things)
        {

            if (!ModelState.IsValid) return View("Create", things);

            var entity = _thingRepository.Add(things);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            ViewBag.categories = _categoryRepository.GetListItems();

            if (id == null)
            {
                return NotFound();
            }

            var things= _mapper.Map<ThingsViewModel>(_thingRepository.GetById(id.Value));
            if (things == null)
            {
                return NotFound();
            }
            return View(things);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ThingsViewModel entity)
        {
            if (id != entity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var thing = _mapper.Map<Thing>(entity);
                _thingRepository.Update(thing);

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

            var things = _mapper.Map<ThingsViewModel>(_thingRepository.GetById(id.Value));
            if (things == null)
            {
                return NotFound();
            }

            return View(things);
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var thing = _mapper.Map<ThingsViewModel>(_thingRepository.GetById(id));
            if (thing == null)
            {
                return NotFound();
            }

            return View(thing);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var thing = _thingRepository.GetById(id);
            if (thing is null)
            {
                return NotFound();
            }

            _thingRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
