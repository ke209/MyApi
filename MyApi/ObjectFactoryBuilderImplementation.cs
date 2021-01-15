using System;
using System.Collections.Generic;
using System.Reflection;

namespace MyApi
{
    public class ObjectFactoryBuilderImplementation<TApi> : ObjectFactoryBuilderImplementation, IObjectFactoryBuilder<TApi>
    {
        public ObjectFactoryBuilderImplementation(IServiceProvider serviceProvider, MyApiSiteSettings settings = null) : base(serviceProvider, typeof(TApi), settings)
        {
        }
    }

    public class ObjectFactoryBuilderImplementation : IObjectFactoryBuilder
    {
        readonly Dictionary<string, SiteMetaInfo> interfaceProperties;
        private readonly MyApiSiteSettings _myApiSettings;
        private readonly IServiceProvider _serviceProvider;

        public ObjectFactoryBuilderImplementation(IServiceProvider serviceProvider, Type myApiSiteType, MyApiSiteSettings myApiSettings = null)
        {
            var targetInterfaceInheritedInterfaces = myApiSiteType.GetInterfaces();

            _serviceProvider = serviceProvider;
            _myApiSettings = myApiSettings ?? new MyApiSiteSettings();

            if (myApiSiteType == null || !myApiSiteType.GetTypeInfo().IsInterface)
            {
                throw new ArgumentException("targetInterface must be an Interface");
            }

            var dict = new Dictionary<string, SiteMetaInfo>();

            AddInterfaceProperties(myApiSiteType, dict);
            foreach (var inheritedInterface in targetInterfaceInheritedInterfaces)
            {
                AddInterfaceProperties(inheritedInterface, dict);
            }

            interfaceProperties = dict;
        }

        public Func<T> BuildRestResultFuncForProperty<T>(string propertyName)
        {
            if (!interfaceProperties.ContainsKey(propertyName))
            {
                throw new ArgumentException("Property must be defined and have an Import attribute");
            }

            var restMethod = interfaceProperties[propertyName];
            var rxFuncMi = this.GetType().GetMethod(nameof(BuildFuncForProperty), BindingFlags.NonPublic | BindingFlags.Instance);
            var rxFunc = (MulticastDelegate)(rxFuncMi.MakeGenericMethod(restMethod.ReturnResultType)).Invoke(this, new[] { restMethod });

            return () =>
            {
                var result = rxFunc.DynamicInvoke();
                if (result == null)
                    return default(T);
                else
                    return (T)result;
            };
        }


        Func<T> BuildFuncForProperty<T>(SiteMetaInfo restMethod)
        {
            return () =>
            {
                var result = _serviceProvider.GetService(typeof(T));
                if (result == null)
                    return default(T);
                else
                    return (T)result;
            };
        }


        void AddInterfaceProperties(Type myApiSiteType, Dictionary<string, SiteMetaInfo> properties)
        {
            foreach (var propertyInfo in myApiSiteType.GetProperties())
            {
                var key = $"{propertyInfo.Name}";
                properties.Add(key, new SiteMetaInfo(myApiSiteType, propertyInfo, _myApiSettings));
            }
        }
    }


}
