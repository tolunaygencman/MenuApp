using AutoMapper;
using MenuApp.Business.Abstracts;
using MenuApp.Business.Constants;
using MenuApp.Business.DTOs.Categories;
using MenuApp.Core.Utilities.Results;
using MenuApp.Core.Utilities.Results.Concrete;
using MenuApp.DataAccess.Abstracts;
using MenuApp.Entity.Concretes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MenuApp.Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;


        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            
        }
        public async Task<IDataResult<CategoryDto>> AddAsync(CategoryCreateDto entity)
        {
            var categoryCreate = await _categoryRepository.AddAsync(_mapper.Map<Category>(entity));
            if (categoryCreate is null)
            {
                return new ErrorDataResult<CategoryDto>(Messages.CategoryAddFail);
            }
            return new SuccessDataResult<CategoryDto>(_mapper.Map<CategoryDto>(categoryCreate), Messages.CategoryAddSuccess);
        }

        public async Task<IDataResult<List<CategoryListDto>>> GetAllAsync(Guid id)
        {           
            var categoryList = await _categoryRepository.GetAllAsync(x=>x.MenuId == id);
            return new SuccessDataResult<List<CategoryListDto>>(_mapper.Map<List<CategoryListDto>>(categoryList), Messages.ListedSuccess);
        }

        public async Task<IDataResult<CategoryDto>> GetByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category is null)
            {
                return new ErrorDataResult<CategoryDto>(Messages.CategoryDoesntExist);
            }
            return new SuccessDataResult<CategoryDto>(_mapper.Map<CategoryDto>(category), Messages.ListedSuccess);
        }
    }
}
