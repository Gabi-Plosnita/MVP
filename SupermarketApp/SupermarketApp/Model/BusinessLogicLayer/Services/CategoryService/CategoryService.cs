using SupermarketApp.Model.DataAccessLayer.Repository;
using SupermarketApp.Model.EntityLayer;
using SupermarketApp.Model.BusinessLogicLayer.Mappers;

namespace SupermarketApp.Model.BusinessLogicLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<CategoryResponseDto> GetCategories()
        {
            var categories = _categoryRepository.GetCategories();
            var categoryResponseDtos = categories.MapToListOfCategoryResponseDto();
            return categoryResponseDtos;
        }

        public CategoryResponseDto GetCategory(int id)
        {
            try
            {
                var category = _categoryRepository.GetCategory(id);
                var categoryResponseDto = category.MapToCategoryResponseDto();
                return categoryResponseDto;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void AddCategory(CategoryRequestDto categoryDto)
        {
            try
            {
                var category = categoryDto.MapToCategory();
                _categoryRepository.AddCategory(category);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateCategory(int id, CategoryRequestDto categoryDto)
        {
            try
            {
                var category = categoryDto.MapToCategory();
                _categoryRepository.UpdateCategory(id, category);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void DeleteCategory(int id)
        {
            try
            {
                _categoryRepository.DeleteCategory(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public double GetTotalCategoryValue(int id)
        {
            try
            {
                var value = _categoryRepository.GetTotalCategoryValue(id);
                return value;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<ProductResponseDto> GetProductsFromCategory(int id)
        {
            try
            {
                var products = _categoryRepository.GetProductsFromCategory(id);
                var productResponseDtos = products.MapToListOfProductResponseDto();
                return productResponseDtos;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
    }
}
