using MyApi;

namespace Respository
{
    [ExportApi(typeof(UserDataContext))]
    public class UserDataContext
    {
        public string ConnextionString { get; set; } = "sqlserver";
    }
}
