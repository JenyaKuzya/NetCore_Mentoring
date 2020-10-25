using NetCore_Mentoring.BLL.Models;
using System.Collections.Generic;

namespace NetCore_Mentoring.BLL.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
    }
}
