using GSC_API.Dto;
using GSC_API.Entities;

namespace GSC_API.DataAccess
{
    public interface ICategoryRepository
    {
        Category Add(CategoryDTO entity);
        bool Delete(int id);

        void Update(Category entity);
        Category? GetById(int id);

        List<Category> GetAll();
    }
}
