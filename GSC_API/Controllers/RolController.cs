using AutoMapper;
using GSC_API.DataAccess;
using GSC_API.Dto;
using GSC_API.Entities;
using GSC_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GSC_API.Controllers
{
    public class RolController : Controller
    {
        private readonly IRolRepository _rolRepository;        
        private readonly IMapper _mapper;

        public RolController(IRolRepository rolRepository,IMapper mapper) { 
        
            _rolRepository = rolRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var rols = _rolRepository.GetAll();
            List<RolViewModel> rolsviewmodel = _mapper.Map<List<RolViewModel>>(rols);
            return View(rolsviewmodel);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RolDTO rol)
        {
            if (!ModelState.IsValid)
                return View("Create", rol);

            var entity = _rolRepository.Add(rol);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rol = _mapper.Map<RolViewModel>(_rolRepository.GetById(id.Value));
            if (rol == null)
            {
                return NotFound();
            }
            return View(rol);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RolViewModel entity)
        {
            if (id != entity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var rol = _mapper.Map<Rol>(entity);
                _rolRepository.Update(rol);

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

            var rol = _mapper.Map<RolViewModel>(_rolRepository.GetById(id.Value));
            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var rol = _mapper.Map<RolViewModel>(_rolRepository.GetById(id));
            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var rol = _rolRepository.GetById(id);
            if (rol is null)
            {
                return NotFound();
            }

            _rolRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
