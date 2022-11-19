using AutoMapper;
using GSC_API.Entities;
using GSC_API.Models;
using Microsoft.EntityFrameworkCore;

namespace GSC_API.DataAccess
{
    public class ThingRepository : IThingRepository
    {
        private readonly LoanDBContext _context;
        private readonly IMapper _mapper;

        public ThingRepository(LoanDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Thing Add(ThingsViewModel entity)
        {
            var thing = _mapper.Map<Thing>(entity);
            var savedEntity = _context.Things.Add(thing);
            _ = _context.SaveChanges();
            return savedEntity.Entity;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Thing> GetAll()
        {
            return _context
                   .Things
                   .Include(c => c.Category)
                   .ToList();
        }

        public Thing? GetById(int id)
        {
            var thing = _context
                        .Things
                        .Include(c => c.Category)
                        .Where(c => c.Id == id).SingleOrDefault();

            if (thing == null) throw new KeyNotFoundException("Person not found");

            return thing;
        }

        public void Update(Thing entity)
        {
               _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
