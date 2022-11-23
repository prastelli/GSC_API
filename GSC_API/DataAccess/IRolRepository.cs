using GSC_API.Dto;
using GSC_API.Entities;
using GSC_API.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GSC_API.DataAccess
{
    public interface IRolRepository
    {
        Rol Add(RolDTO entity);
        bool Delete(int id);

        void Update(Rol entity);
        Rol? GetById(int id);

        List<Rol> GetAll();

        List<SelectListItem> GetListItems();
    }
}
