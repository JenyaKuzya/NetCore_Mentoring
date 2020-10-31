using AutoMapper;
using NetCore_Mentoring.BLL.Models;
using NetCore_Mentoring.BLL.Services.Interfaces;
using NetCore_Mentoring.DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace NetCore_Mentoring.BLL.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly IMapper mapper;

        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            this.supplierRepository = supplierRepository;
            this.mapper = mapper;
        }

        public IEnumerable<SupplierModel> GetAll()
        {
            var suppliers = supplierRepository.GetAll();

            return mapper.Map<IEnumerable<SupplierModel>>(suppliers);
        }
    }
}
