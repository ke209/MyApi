namespace MyApi
{
    public interface ISiteService
    {
        T GetService<T>(string name = null) where T : class;
        T GetExtensionService<T>()
            where T : class;
    }
}
