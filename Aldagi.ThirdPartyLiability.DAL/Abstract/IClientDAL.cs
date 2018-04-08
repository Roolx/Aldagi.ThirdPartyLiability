using Aldagi.Common.Enums;
using Aldagi.Common.Models;
using Aldagi.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aldagi.ThirdPartyLiability.DAL.Abstract
{
    public interface IClientDAL
    {
        IEnumerable<Client> GetClients(int internalUserId);
        ClientDetails GetClientDetails(int clientId, int internalUserId);

        void AddClient(ClientRegistrationModel clientRegistration, int internalUserId);

        void UpdateClientTPLTerm(int clientId, int tplTermId, int internalUserId);
        void UpdateClientTPLStatus(int clientId, TplStatus status, int internalUserId);

        void DeleteClientTPL(int clientId, int internalUserId);
        LiabilityDetails GetClientLiability(int clientId, int internalUserId);
        TplStatus GetClientLiabilityStatus(int clientId, int internalUserId);
    }
}
