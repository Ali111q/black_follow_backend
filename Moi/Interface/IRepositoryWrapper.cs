using GaragesStructure.Interface;

namespace GaragesStructure.Repository
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IPermissionRepository Permission { get; }

        IRoleRepository Role { get; }

        // here to add

        
        ICountryRepository Country { get; }
        
        INotificationRepository Notification { get; }
        
    }
}
