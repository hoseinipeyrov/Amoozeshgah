using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amoozeshgah.Common.Domain
{
    public interface IUserInfo
    {
        int UserTypeId { get; }
        int UserId { get; }
        bool IsAuthenticated { get; }
    }
}