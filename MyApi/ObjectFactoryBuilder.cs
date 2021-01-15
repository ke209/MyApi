using System;

namespace MyApi
{
    public static class ObjectFactoryBuilder
    {

        public static IObjectFactoryBuilder<T> ForType<T>(IServiceProvider serviceProvider, MyApiSiteSettings settings = null)
        {
            return new ObjectFactoryBuilderImplementation<T>(serviceProvider, settings);
        }


        public static IObjectFactoryBuilder ForType(IServiceProvider serviceProvider, Type myApiSiteType, MyApiSiteSettings settings)
        {
            return new ObjectFactoryBuilderImplementation(serviceProvider, myApiSiteType, settings);
        }

    }
}
