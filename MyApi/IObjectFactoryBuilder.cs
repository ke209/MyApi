using System;

namespace MyApi
{
    public interface IObjectFactoryBuilder
    {
        Func<T> BuildRestResultFuncForProperty<T>(string propertyName);
    }

    public interface IObjectFactoryBuilder<T> : IObjectFactoryBuilder
    {
    }


}
