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
        public async Task<IDataResult<CategoryDTO>> AddAsync(CategoryCreateDTO entity)
        {
            var categoryCreate = await _categoryRepository.AddAsync(_mapper.Map<Category>(entity));
            if (categoryCreate is null)
            {
                return new ErrorDataResult<CategoryDTO>(Messages.CategoryAddFail);
            }
            return new SuccessDataResult<CategoryDTO>(_mapper.Map<CategoryDTO>(categoryCreate), Messages.CategoryAddSuccess);
        }

        public async Task<IDataResult<List<CategoryListDTO>>> GetAllAsync(Guid id)
        {           
            var categoryList = await _categoryRepository.GetAllAsync(x=>x.MenuId == id);
            return new SuccessDataResult<List<CategoryListDTO>>(_mapper.Map<List<CategoryListDTO>>(categoryList), Messages.ListedSuccess);
        }     
    }
}
