using GSC_API.Dto;
using GSC_API.Entities;
using GSC_API.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GSC_API.DataAccess
{
    public interface ICategoryRepository
    {
        Category Add(CategoryViewModel entity);
        bool Delete(int id);

        void Update(Category entity);
        Category? GetById(int id);

        List<Category> GetAll();
       
        List<SelectListItem> GetListItems();
    }
}
