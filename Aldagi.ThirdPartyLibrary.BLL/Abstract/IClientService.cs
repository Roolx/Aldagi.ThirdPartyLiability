using Aldagi.Common.Entities;
using Aldagi.Common.Enums;
using Aldagi.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aldagi.ThirdPartyLiability.BLL.Abstract
{
    public interface IClientService
    {
        IEnumerable<Client> GetClients(int internalUserId);
        ClientDetails GetClientDetails(int clientId, int internalUserId);

        void AddClient(ClientRegistrationModel clientRegistration, int internalUserId);

        void UpdateClientTPLTerm(int clientId, int tplTermId, int internalUserId);
        void UpdateClientTPLStatus(int clientId, TplStatus status, int internalUserId);

        /// <exception cref="ClientNotFoundException">Why it's thrown.</exception>
        void DeleteClientTPL(int clientId, int internalUserId);

        /// <exception cref="ClientNotFoundException">Why it's thrown.</exception>
        LiabilityDetails GetClientLiability(int clientId, int internalUserId);
        TplStatus GetClientLiabilityStatus(int clientId, int internalUserId);
    }
}
