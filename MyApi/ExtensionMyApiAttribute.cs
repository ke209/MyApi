using System;

namespace MyApi
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
    public class ExtensionMyApiAttribute : System.Attribute
    {
        public ExtensionMyApiAttribute(string typeFullName, string methodName)
        {
            this.TypeFullName = typeFullName;
            this.MethodName = methodName;
        }

        public string TypeFullName { get;  }
        public string MethodName { get; set; }
    }
}
