using AutoMapper;
using BackEndStructuer.Interface;
using BackEndStructuer.Repository;
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
private IFinancialMovementRepository _FinancialMovement;

public IFinancialMovementRepository FinancialMovement {
    get {
        if(_FinancialMovement == null) {
            _FinancialMovement = new FinancialMovementRepository(_context, _mapper);
        }
        return _FinancialMovement;
    }
}

private IOrderRepository _Order;

public IOrderRepository Order {
    get {
        if(_Order == null) {
            _Order = new OrderRepository(_context, _mapper);
        }
        return _Order;
    }
}
private IServiceRepository _Service;

public IServiceRepository Service {
    get {
        if(_Service == null) {
            _Service = new ServiceRepository(_context, _mapper);
        }
        return _Service;
    }
}
private ISubCategoryRepository _SubCategory;

public ISubCategoryRepository SubCategory {
    get {
        if(_SubCategory == null) {
            _SubCategory = new SubCategoryRepository(_context, _mapper);
        }
        return _SubCategory;
    }
}
private ICategoriesRepository _Categories;

public ICategoriesRepository Categories {
    get {
        if(_Categories == null) {
            _Categories = new CategoriesRepository(_context, _mapper);
        }
        return _Categories;
    }
}

        
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
