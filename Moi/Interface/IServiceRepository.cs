using BackEndStructuer.Entities;
using GaragesStructure.Interface;

namespace BackEndStructuer.Interface
{
    public interface IServiceRepository : IGenericRepository<Service , Guid>
    {
         
    }
}
