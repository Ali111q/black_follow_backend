using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;
using GaragesStructure.DATA;
using GaragesStructure.Repository;

namespace BackEndStructuer.Repository
{

    public class SubCategoryRepository : GenericRepository<SubCategory , Guid> , ISubCategoryRepository
    {
        public SubCategoryRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
