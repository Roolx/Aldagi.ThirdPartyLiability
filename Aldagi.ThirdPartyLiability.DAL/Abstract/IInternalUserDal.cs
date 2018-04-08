using Aldagi.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aldagi.ThirdPartyLiability.DAL.Abstract
{
    public interface IInternalUserDAL
    {
        IEnumerable<InternalUser> GetInternalUsers();
        InternalUser GetInternalUserById(int internalUserId);
    }
}
