using AutoMapper;
using NetCore_Mentoring.BLL.Models;
using NetCore_Mentoring.DAL.Entities;

namespace NetCore_Mentoring.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Supplier, SupplierModel>().ReverseMap();
        }
    }
}
