using MyApi;

namespace Respository
{
    [ExportMyApi(typeof(UserDataContext))]
    public class UserDataContext
    {
        public string ConnextionString { get; set; } = "sqlserver";
    }
}
