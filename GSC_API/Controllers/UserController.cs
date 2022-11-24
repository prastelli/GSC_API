using AutoMapper;
using GSC_API.DataAccess;
using GSC_API.Entities;
using GSC_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GSC_API.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IRolRepository _rolRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper, IRolRepository rolRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _rolRepository = rolRepository;
        }
        public IActionResult Index()
        {
            var user = _userRepository.GetAll();
            var userviewmodel = _mapper.Map<List<UserViewModel>>(user);
            return View(userviewmodel);
          }
        public IActionResult Create() //Que raro que es este controller verdad?
        {
            ViewBag.roles = _rolRepository.GetListItems();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserViewModel user)
        {

            if (!ModelState.IsValid) return View("Create", user);

            var entity = _userRepository.Add(user);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            ViewBag.roles = _rolRepository.GetListItems();

            if (id == null)
            {
                return NotFound();
            }

            var user = _mapper.Map<UserViewModel>(_userRepository.GetById(id.Value));
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UserViewModel entity)
        {
            if (id != entity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var user = _userRepository.GetById(id);
                user = _mapper.Map<User>(entity);
                _userRepository.Update(user);

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

            var user = _mapper.Map<UserViewModel>(_userRepository.GetById(id.Value));
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var user = _mapper.Map<UserViewModel>(_userRepository.GetById(id));
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _userRepository.GetById(id);
            if (user is null)
            {
                return NotFound();
            }

            _userRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
