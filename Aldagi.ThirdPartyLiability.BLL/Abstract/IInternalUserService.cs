using Aldagi.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aldagi.ThirdPartyLiability.BLL.Abstract
{
    public interface IInternalUserService
    {
        IEnumerable<InternalUser> GetInternalUsers();
        InternalUser GetInternalUserById(int internalUserId);
    }
}
