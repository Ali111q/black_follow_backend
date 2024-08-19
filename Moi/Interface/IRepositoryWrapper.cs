using BackEndStructuer.Interface;
using GaragesStructure.Interface;

namespace GaragesStructure.Repository
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IPermissionRepository Permission { get; }

        IRoleRepository Role { get; }

        // here to add
IOrderRepository Order{get;}
IServiceRepository Service{get;}
ISubCategoryRepository SubCategory{get;}
ICategoriesRepository Categories{get;}

        
        ICountryRepository Country { get; }
        
        INotificationRepository Notification { get; }
        
    }
}
