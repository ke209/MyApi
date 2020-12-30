using System;
using System.Collections.Generic;
using System.Text;
using ICore.ICore;
using ICore.Sites;
using Respository;

namespace ICore.Sites
{
    public static class RespositorySiteExtension
    {
        public static IDbContextRepository<UserDataContext> UserDataContext(this IRespositorySite site)
        {
            return new DbContextRepository<UserDataContext>();
        }
    }
}
