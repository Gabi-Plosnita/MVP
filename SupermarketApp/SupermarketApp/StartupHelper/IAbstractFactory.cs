namespace SupermarketApp.StartupHelper
{
    public interface IAbstractFactory<T>
    {
        T Create();
    }
}