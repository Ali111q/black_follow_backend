using System.Text.Json.Nodes;
using AutoMapper;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using GaragesStructure.DATA.DTOs.Country;
using GaragesStructure.DATA.DTOs.roles;
using GaragesStructure.DATA.DTOs.User;
using GaragesStructure.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OneSignalApi.Model;

// here to implement


namespace GaragesStructure.Helpers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {

            CreateMap<AppUser, UserDto>();
            CreateMap<RegisterForm, App>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateUserForm, AppUser>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Role, RoleDto>();
            CreateMap<AppUser, AppUser>();

            CreateMap<Permission, PermissionDto>();


            CreateMap<Country, CountryDto>();
            CreateMap<CountryForm, Country>();
            CreateMap<CountryUpdate, Country>()
                .ForAllMembers(m => m.Condition(p => p != null))
                ;


            // here to add
CreateMap<Order, OrderDto>();
CreateMap<OrderForm,Order>();
CreateMap<OrderUpdate,Order>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<Service, ServiceDto>();
CreateMap<ServiceForm,Service>();
CreateMap<ServiceUpdate,Service>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<SubCategory, SubCategoryDto>();
CreateMap<SubCategoryForm,SubCategory>();
CreateMap<SubCategoryUpdate,SubCategory>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<Categories, CategoriesDto>();
CreateMap<CategoriesForm,Categories>();
CreateMap<CategoriesUpdate,Categories>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
CreateMap<Categories, CategoriesGetByIdDto>();

        }
    }
}
