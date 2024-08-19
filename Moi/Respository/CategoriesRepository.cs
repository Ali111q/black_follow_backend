using AutoMapper;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;
using GaragesStructure.DATA;
using GaragesStructure.Repository;

namespace BackEndStructuer.Repository
{
    public class CategoriesRepository : GenericRepository<Categories, Guid>, ICategoriesRepository
    {
        public CategoriesRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
