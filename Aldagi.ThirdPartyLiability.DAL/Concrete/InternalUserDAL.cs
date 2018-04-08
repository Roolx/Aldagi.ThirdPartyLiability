using Aldagi.ThirdPartyLiability.DAL.Abstract;
using Aldagi.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aldagi.ThirdPartyLiability.DAL.Concrete
{
    public class InternalUserDAL : IInternalUserDAL
    {
        private readonly DatabaseContext _databaseContext;
        public InternalUserDAL(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public InternalUser GetInternalUserById(int internalUserId)
        {
            var internalUser = _databaseContext.InternalUsers.Where(x => x.InternalUserId == internalUserId).FirstOrDefault();
            return new InternalUser()
            {
                InternalUserId = internalUser.InternalUserId,
                Name = internalUser.Name
            };
        }

        public IEnumerable<InternalUser> GetInternalUsers()
        {
            throw new NotImplementedException();
        }
    }
}
