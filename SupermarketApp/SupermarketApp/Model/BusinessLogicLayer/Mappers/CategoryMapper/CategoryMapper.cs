using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.BusinessLogicLayer.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryResponseDto MapToCategoryResponseDto(this Category category)
        {
          return new CategoryResponseDto
          {
              CategoryId = category.CategoryId,
              Name = category.Name,
          };
        }

        public static List<CategoryResponseDto> MapToListOfCategoryResponseDto(this List<Category> categories)
        {
            return categories.Select(category => category.MapToCategoryResponseDto()).ToList();
        }

        public static Category MapToCategory(this CategoryRequestDto categoryRequestDto)
        {
            return new Category
            {
                Name = categoryRequestDto.Name,
            };
        }

        public static CategoryRequestDto MapToCategoryRequestDto(this CategoryResponseDto categoryResponseDto)
        {
            return new CategoryRequestDto
            {
                Name = categoryResponseDto.Name,
            };
        }
    }
}
