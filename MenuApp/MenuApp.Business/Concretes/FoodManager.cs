using AutoMapper;
using MenuApp.Business.Abstracts;
using MenuApp.Business.Constants;
using MenuApp.Business.DTOs.Foods;
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
    public class FoodManager : IFoodService
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;

        public FoodManager(IFoodRepository foodRepository, IMapper mapper)
        {
            _foodRepository = foodRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<FoodDto>> AddAsync(FoodCreateDto entity)
        {
            var foodCreate = await _foodRepository.AddAsync(_mapper.Map<Food>(entity));
            if (foodCreate is null)
            {
                return new ErrorDataResult<FoodDto>(Messages.FoodAddFail);
            }
            return new SuccessDataResult<FoodDto>(_mapper.Map<FoodDto>(foodCreate), Messages.FoodAddSuccess);
        }

        public async Task<bool> DeleteAsync(FoodDto entity)
        {
            var deletedFood = await _foodRepository.GetAsync(x => x.Id == entity.Id);
            return await _foodRepository.DeleteAsync(deletedFood);
        }

        public async Task<IDataResult<List<FoodListDto>>> GetAllAsync(Guid id)
        {
            var foodList = await _foodRepository.GetAllAsync(x => x.CategoryId == id);
            return new SuccessDataResult<List<FoodListDto>>(_mapper.Map<List<FoodListDto>>(foodList), Messages.ListedSuccess);
        }

        public async Task<IDataResult<FoodDto>> GetByIdAsync(Guid id)
        {
            var food = await _foodRepository.GetByIdAsync(id);
            if (food is null)
            {
                return new ErrorDataResult<FoodDto>(Messages.FoodNotFound);
            }
            return new SuccessDataResult<FoodDto>(_mapper.Map<FoodDto>(food), Messages.FoundSuccess);
        }

        public async Task<IDataResult<FoodDto>> UpdateAsync(FoodUpdateDto entity)
        {
            var foodTobeUpdated = await _foodRepository.GetByIdAsync(entity.Id);
            var mappedFood = _mapper.Map(entity, foodTobeUpdated);
            var updatedFood = await _foodRepository.UpdateAsync(mappedFood);

            if (updatedFood is null)
            {
                return new ErrorDataResult<FoodDto>(_mapper.Map<FoodDto>(updatedFood), Messages.MenuUpdateFail);
            }
            return new SuccessDataResult<FoodDto>(_mapper.Map<FoodDto>(updatedFood), Messages.MenuUpdateSuccess);
        }

        public async Task<IDataResult<FoodDto>> UpdateWithoutImgAsync(FoodUpdateWithoutImgDto entity)
        {
            var foodTobeUpdated = await _foodRepository.GetByIdAsync(entity.Id);
            var mappedFood = _mapper.Map(entity, foodTobeUpdated);
            var updatedFood = await _foodRepository.UpdateAsync(mappedFood);

            if (updatedFood is null)
            {
                return new ErrorDataResult<FoodDto>(_mapper.Map<FoodDto>(updatedFood), Messages.MenuUpdateFail);
            }
            return new SuccessDataResult<FoodDto>(_mapper.Map<FoodDto>(updatedFood), Messages.MenuUpdateSuccess);
        }
    }
}
