using System;
using System.Collections.Generic;
using System.Text;
using ICore.ICore;
using MyApi.Attribute;

namespace Respository
{
    [ExportApi(typeof(UserDataContext))]
    public class UserDataContext
    {
        public string ConnextionString { get; set; } = "sqlserver";
    }
}
