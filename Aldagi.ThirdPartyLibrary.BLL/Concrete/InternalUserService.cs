using Aldagi.ThirdPartyLiability.DAL.Abstract;
using Aldagi.ThirdPartyLiability.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Aldagi.Common.Entities;

namespace Aldagi.ThirdPartyLiability.BLL.Concrete
{
    public class InternalUserService : IInternalUserService
    {
        private readonly IInternalUserDAL _internalUserDAL;
        public InternalUserService(IInternalUserDAL internalUserDAL)
        {
            _internalUserDAL = internalUserDAL;
        }

        public InternalUser GetInternalUserById(int internalUserId)
        {
            return _internalUserDAL.GetInternalUserById(internalUserId);
        }

        public IEnumerable<InternalUser> GetInternalUsers()
        {
            throw new NotImplementedException();
        }
    }
}
