using AutoMapper;
using GSC_API.Dto;
using GSC_API.Entities;
using GSC_API.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GSC_API.DataAccess
{
    public class RolRepository : IRolRepository
    {
        private readonly LoanDBContext _context;
        private readonly IMapper _mapper;

        public RolRepository(LoanDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Rol Add(RolDTO entity)
        {
            var rol = _mapper.Map<Rol>(entity);
            var savedEntity = _context.RoleModel.Add(rol);
            _context.SaveChanges();
            return savedEntity.Entity;
        }

        public bool Delete(int id)
        {
            var rol = _context.RoleModel.Find(id);

            if (rol == null)
            {
                return false;
            }
            _context.RoleModel.Remove(rol);
            _context.SaveChanges();

            return true;
        }

        public List<Rol> GetAll()
        {
            return _context.RoleModel.ToList();
        }

        public Rol? GetById(int id)
        {
            var rol = _context.RoleModel.Find(id);
            if (rol == null) throw new KeyNotFoundException("Person not found");

            return rol;
        }

        public List<SelectListItem> GetListItems()
        {
            var lsiRoles = new List<SelectListItem>();
            var roles = GetAll();
            lsiRoles = roles.Select(c => new SelectListItem()
            {
                Text = c.RolDescription,
                Value = c.Id.ToString()
            }).ToList();

            var dfiRoles = new SelectListItem()
            {
                Text = "Select Rol",
                Value = ""
            };

            lsiRoles.Insert(0, dfiRoles);

            return lsiRoles;
        }

        public void Update(Rol entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
