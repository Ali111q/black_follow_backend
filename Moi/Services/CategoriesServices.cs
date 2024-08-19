using AutoMapper;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using GaragesStructure.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndStructuer.Services
{
    public interface ICategoriesServices
    {
        Task<(Categories? categories, string? error)> Create(CategoriesForm categoriesForm);
        Task<(List<CategoriesDto> categories, int? totalCount, string? error)> GetAll(CategoriesFilter filter);
        Task<(Categories? categories, string? error)> Update(Guid id, CategoriesUpdate categoriesUpdate);
        Task<(Categories? categories, string? error)> Delete(Guid id);
    }

    public class CategoriesServices : ICategoriesServices
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CategoriesServices(IMapper mapper, IRepositoryWrapper repositoryWrapper)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<(Categories? categories, string? error)> Create(CategoriesForm categoriesForm)
        {
            try
            {
                // Map CategoriesForm to Categories entity
                var category = _mapper.Map<Categories>(categoriesForm);

                // Add the new category to the repository
                var createdCategory = await _repositoryWrapper.Categories.Add(category);

                return (createdCategory, null);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

        public async Task<(List<CategoriesDto> categories, int? totalCount, string? error)> GetAll(CategoriesFilter filter)
        {
            try
            {
                // Get all categories with filtering, pagination, and mapping to DTO
                var data = await _repositoryWrapper.Categories.GetAll<CategoriesDto>(filter.PageNumber, filter.PageSize, filter.Deleted);
                return (data.data, data.totalCount, null);
            }
            catch (Exception ex)
            {
                return (new List<CategoriesDto>(), null, ex.Message);
            }
        }

        public async Task<(Categories? categories, string? error)> Update(Guid id, CategoriesUpdate categoriesUpdate)
        {
            try
            {
                // Get the existing category by ID
                var existingCategory = await _repositoryWrapper.Categories.GetById(id);

                if (existingCategory == null)
                {
                    return (null, "Category not found");
                }

                // Map the update DTO to the existing entity
               existingCategory= _mapper.Map(categoriesUpdate, existingCategory);

                // Update the category in the repository
                await _repositoryWrapper.Categories.Update(existingCategory);

                return (existingCategory, null);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

        public async Task<(Categories? categories, string? error)> Delete(Guid id)
        {
            try
            {
                // Soft delete the category by ID
                var deletedCategory = await _repositoryWrapper.Categories.SoftDelete(id);

                return (deletedCategory, null);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
    }
}
