namespace MyApi
{
    public abstract class SiteBase : ISiteService
    {
        private readonly IObjectFactoryBuilder _builder;
        public SiteBase(IObjectFactoryBuilder builder)
        {
            _builder = builder;
        }

        public T GetService<T>(string name = null)
            where T : class
        {
            if (string.IsNullOrEmpty(name))
                name = typeof(T).Name;

            var func = _builder?.BuildRestResultFuncForProperty<T>(name);
            return func?.Invoke();
        }

        public T GetExtensionService<T>()
            where T : class
        {
            var func = _builder?.BuildRestResultFuncForExtension<T>();
            return func?.Invoke();
        }
    }
}
