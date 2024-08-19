using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;

namespace BackEndStructuer.Repository
{

    public class CategoriesRepository : GenericRepository<Categories , Guid> , ICategoriesRepository
    {
        public CategoriesRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
