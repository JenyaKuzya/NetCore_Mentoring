using NetCore_Mentoring.DAL.Entities;
using System.Collections.Generic;

namespace NetCore_Mentoring.DAL.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
    }
}
