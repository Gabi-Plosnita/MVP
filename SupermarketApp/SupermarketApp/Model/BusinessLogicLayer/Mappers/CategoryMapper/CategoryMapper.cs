using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.BusinessLogicLayer.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryResponseDto MapToCategoryResponseDto(this Category category)
        {
           var categoryResponseDto = new CategoryResponseDto
           {
               CategoryId = category.CategoryId,
               Name = category.Name,
           };
           
           return categoryResponseDto;
        }

        public static List<CategoryResponseDto> MapToListOfCategoryResponseDto(this List<Category> categories)
        {
            var categoryResponseDtos = new List<CategoryResponseDto>();
            foreach (var category in categories)
            {
                categoryResponseDtos.Add(category.MapToCategoryResponseDto());
            }

            return categoryResponseDtos;
        }

        public static Category MapToCategory(this CategoryRequestDto categoryRequestDto)
        {
            var category = new Category
            {
                Name = categoryRequestDto.Name,
            };

            return category;
        }
    }
}
