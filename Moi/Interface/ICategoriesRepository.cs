using BackEndStructuer.Entities;
using GaragesStructure.Interface;
using System;

namespace BackEndStructuer.Interface
{
    public interface ICategoriesRepository : IGenericRepository<Categories, Guid>
    {
    }
}
