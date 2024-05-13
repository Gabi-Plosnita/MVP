namespace SupermarketApp.Model.Entities
{
    public static class ECategoryExtensions
    {
        public static string ToString(this ECategory category)
        {
            switch (category)
            {
                case ECategory.Food:
                    return "Food";
                case ECategory.Clothing:
                    return "Clothing";
                case ECategory.Electronics:
                    return "Electronics";
                case ECategory.Hygiene:
                    return "Hygiene";
                case ECategory.Cleaning:
                    return "Cleaning";
                default:
                    return "Unknown";
            }
        }

    }
}
