using System;

namespace MyApi
{
    public interface IObjectFactoryBuilder
    {
        Func<T> BuildRestResultFuncForProperty<T>(string propertyName);
        Func<T> BuildRestResultFuncForExtension<T>();
    }

    public interface IObjectFactoryBuilder<T> : IObjectFactoryBuilder
    {
    }


}
