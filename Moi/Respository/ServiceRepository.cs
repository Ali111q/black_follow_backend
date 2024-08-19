using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;

namespace BackEndStructuer.Repository
{

    public class ServiceRepository : GenericRepository<Service , Guid> , IServiceRepository
    {
        public ServiceRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
