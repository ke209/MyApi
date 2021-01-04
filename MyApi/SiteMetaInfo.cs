using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyApi
{
    public class SiteMetaInfo
    {
        private Type _apiSiteType;
        private MyApiSettings _myApiSettings;

        public SiteMetaInfo(Type apiSiteType, PropertyInfo propertyInfo, MyApiSettings myApiSettings)
        {
            this._apiSiteType = apiSiteType;
            this._myApiSettings = myApiSettings ?? new MyApiSettings();
            this.PropertyInfo = propertyInfo;
            this.ApiSiteType = apiSiteType ?? throw new ArgumentNullException(nameof(apiSiteType));
            this.Name = propertyInfo.Name;

            DetermineReturnTypeInfo(propertyInfo);
        }


        void DetermineReturnTypeInfo(PropertyInfo propertyInfo)
        {
            var returnType = propertyInfo.PropertyType;
            if (returnType.IsGenericType && (propertyInfo.PropertyType.GetGenericTypeDefinition() != typeof(Task<>)
                                             || propertyInfo.PropertyType.GetGenericTypeDefinition() != typeof(IObservable<>)))
            {
                ReturnType = returnType;
                ReturnResultType = returnType.GetGenericArguments()[0];
            }
            else if (returnType == typeof(Task))
            {
                ReturnType = propertyInfo.PropertyType;
                ReturnResultType = typeof(void);
            }
            else
            {
                ReturnType = returnType;
                ReturnResultType = returnType;
            }
        }

        public string Name { get; set; }
        public Type ApiSiteType { get; set; }
        public PropertyInfo PropertyInfo { get; set; }

        public Type ReturnType { get; set; }
        public Type ReturnResultType { get; set; }
    }
}
