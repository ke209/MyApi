using System;
using System.Collections.Generic;
using System.Text;

namespace UniformInterfaces
{
    public interface IObjectFactoryBuilder
    {
         Func<IServiceProvider, object[], object> BuildRestResultFuncForMethod(string methodName, Type[] parameterTypes = null, Type[] genericArgumentTypes = null);
    }
}
