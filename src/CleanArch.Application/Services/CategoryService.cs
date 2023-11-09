using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using CleanArch.Domain.UnitOfWork;

namespace CleanArch.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository repository
            , IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _categoryRepository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddCategory(CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(categoryDto);

            try
            {
                await _categoryRepository.Add(category);

                await _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                await _unitOfWork.Rollback();

                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteCategory(CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(categoryDto);

            await DeleteCategory(category, cancellationToken);
        }

        public async Task DeleteCategoryById(long? id, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetById(id);

            await DeleteCategory(category, cancellationToken);
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories(CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAll();

            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryById(long? id, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetById(id);

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> UpdateCategory(CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(categoryDto);

            try
            {
                var categoryUpdated = await _categoryRepository.Update(category);

                await _unitOfWork.Commit();

                return _mapper.Map<CategoryDto>(categoryUpdated);
            }
            catch (Exception ex)
            {
                await _unitOfWork.Rollback();

                throw new Exception(ex.Message);
            }
        }

        private async Task DeleteCategory(Category category, CancellationToken cancellationToken)
        {
            try
            {
                await _categoryRepository.Delete(category);

                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                await _unitOfWork.Rollback();

                throw new Exception(ex.Message);
            }
        }
    }
}
