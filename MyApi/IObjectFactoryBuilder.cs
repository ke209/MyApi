using System;
using System.Collections.Generic;
using System.Text;

namespace MyApi
{
    public interface IObjectFactoryBuilder
    {
        Func<T> BuildRestResultFuncForProperty<T>(string propertyName);
    }

    public interface IObjectFactoryBuilder<T>:IObjectFactoryBuilder
    {
    }

    
}
