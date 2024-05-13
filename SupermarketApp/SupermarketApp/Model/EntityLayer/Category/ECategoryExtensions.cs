namespace SupermarketApp.Model.EntityLayer
{
    public static class ECategoryExtensions
    {
        public static string ToString(this ECategoryType category)
        {
            switch (category)
            {
                case ECategoryType.Food:
                    return "Food";
                case ECategoryType.Clothing:
                    return "Clothing";
                case ECategoryType.Electronics:
                    return "Electronics";
                case ECategoryType.Hygiene:
                    return "Hygiene";
                case ECategoryType.Cleaning:
                    return "Cleaning";
                default:
                    return "Unknown";
            }
        }

    }
}
