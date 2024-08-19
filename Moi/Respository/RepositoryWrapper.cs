using AutoMapper;
using GaragesStructure.DATA;
using GaragesStructure.Interface;

namespace GaragesStructure.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        private IUserRepository _user;
        private IPermissionRepository _permission;
        private IRoleRepository _role;
        
        private ICountryRepository _country;
        
        public ICountryRepository Country
        {
            get
            {
                if (_country == null)
                {
                    _country = new CountryRepository(_context, _mapper);
                }

                return _country;
            }
        }

        public IRoleRepository Role
        {
            get
            {
                if (_role == null)
                {
                    _role = new RoleRepository(_context, _mapper);
                }

                return _role;
            }
        }

        public IPermissionRepository Permission
        {
            get
            {
                if (_permission == null)
                {
                    _permission = new PermissionRepository(_context, _mapper);
                }

                return _permission;
            }
        }

        

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_context, _mapper);
                }

                return _user;
            }
        }


        public RepositoryWrapper(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // here to add

        
        private INotificationRepository _Notification;
        
        public INotificationRepository Notification
        {
            get
            {
                if (_Notification == null)
                {
                    _Notification = new NotificationRepository(_context, _mapper);
                }

                return _Notification;
            }
        }
        
    }
}
