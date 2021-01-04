using System;
using System.Collections.Generic;
using System.Text;

namespace MyApi
{
    public static class ObjectFactoryBuilder
    {

        public static IObjectFactoryBuilder<T> ForType<T>(IServiceProvider serviceProvider,MyApiSettings settings = null)
        {
            return new ObjectFactoryBuilderImplementation<T>(serviceProvider,settings);
        }


        public static IObjectFactoryBuilder ForType(IServiceProvider serviceProvider,Type myApiSiteType, MyApiSettings settings)
        {
            return new ObjectFactoryBuilderImplementation(serviceProvider,myApiSiteType,settings);
        }

    }
}
