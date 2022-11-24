using AutoMapper;
using GSC_API.Dto;
using GSC_API.Entities;
using GSC_API.Models;
using Microsoft.EntityFrameworkCore;

namespace GSC_API.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly LoanDBContext _context;
        private readonly IMapper _mapper;

        public UserRepository(LoanDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public User Add(UserViewModel entity)
        {
            var user = _mapper.Map<User>(entity);
            var savedEntity = _context.Users.Add(user);
            _context.SaveChanges();
            return savedEntity.Entity;
        }

        public bool Delete(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            _context.SaveChanges();

            return true;
        }

        public List<User> GetAll()
        {
            return _context
                   .Users
                   .Include(c => c.Rol)
                   .ToList();
        }

        public User? GetById(int id)
        {
            var user = _context
                        .Users
                        .Include(c => c.Rol)
                        .Where(c => c.Id == id).SingleOrDefault();

            if (user == null) throw new KeyNotFoundException("Person not found");

            return user;
        }

        public void Update(User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
