namespace MyApi
{
    public abstract class SiteBase
    {
        private readonly IObjectFactoryBuilder _builder;
        public SiteBase(IObjectFactoryBuilder builder)
        {
            _builder = builder;
        }

        protected T GetService<T>(string name)
            where T : class
        {
            var func = _builder?.BuildRestResultFuncForProperty<T>(name);
            return func?.Invoke();
        }
    }
}
