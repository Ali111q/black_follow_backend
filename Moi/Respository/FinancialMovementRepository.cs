using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;
using GaragesStructure.DATA;
using GaragesStructure.Repository;

namespace BackEndStructuer.Repository
{

    public class FinancialMovementRepository : GenericRepository<FinancialMovement , Guid> , IFinancialMovementRepository
    {
        public FinancialMovementRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
