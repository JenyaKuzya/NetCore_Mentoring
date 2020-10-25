using AutoMapper;
using NetCore_Mentoring.BLL.Models;
using Entities = NetCore_Mentoring.DAL.Entities;

namespace NetCore_Mentoring.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Category, Category>();
            CreateMap<Entities.Product, Product>();
        }
    }
}
