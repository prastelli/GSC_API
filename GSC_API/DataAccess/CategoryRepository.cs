using AutoMapper;
using GSC_API.Dto;
using GSC_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GSC_API.DataAccess
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LoanDBContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(LoanDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Category Add(CategoryDTO entity)
        {
            var Category = _mapper.Map<Category>(entity);
            var savedEntity = _context.Categories.Add(Category);
            _ = _context.SaveChanges();
            return savedEntity.Entity;
        }

        public bool Delete(int id)
        {
            var category = _context.Categories.Find(id);

            if (category == null)
            {
                return false;
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return true;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.Include(c =>c.Things).ToList();
        }

        public Category? GetById(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) throw new KeyNotFoundException("Person not found");

            return category;
        }

        public void Update(Category entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
