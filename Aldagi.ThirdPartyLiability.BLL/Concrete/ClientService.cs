using Aldagi.Common.Enums;
using Aldagi.Common.Models;
using Aldagi.ThirdPartyLiability.DAL.Abstract;
using Aldagi.ThirdPartyLiability.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Aldagi.Common.Entities;
using Aldagi.Common.Exceptions;

namespace Aldagi.ThirdPartyLiability.BLL.Concrete
{
    public class ClientService : IClientService
    {
        private readonly IClientDAL _clientDal;
        public ClientService(IClientDAL clientDAL)
        {
            _clientDal = clientDAL;
        }

        public void AddClient(ClientRegistrationModel clientRegistration, int internalUserId)
        {
            _clientDal.AddClient(clientRegistration, internalUserId);
        }

        public void DeleteClientTPL(int clientId, int internalUserId)
        {
            var client = _clientDal.GetClientDetails(clientId, internalUserId);
            if (client == null)
                throw new ClientNotFoundException();
            _clientDal.DeleteClientTPL(clientId, internalUserId);
        }

        public ClientDetails GetClientDetails(int clientId, int internalUserId)
        {
            return _clientDal.GetClientDetails(clientId, internalUserId);
        }

        public LiabilityDetails GetClientLiability(int clientId, int internalUserId)
        {
            try
            {
                return _clientDal.GetClientLiability(clientId, internalUserId);
            }
            catch (DalException)
            {

                throw new ClientNotFoundException();
            }
        }

        public TplStatus GetClientLiabilityStatus(int clientId, int internalUserId)
        {
            try

            {
                return _clientDal.GetClientLiabilityStatus(clientId, internalUserId);
            }

            catch (DalException)
            {

                throw new ClientNotFoundException();
            }
        }

        public IEnumerable<Client> GetClients(int internalUserId)
        {
            return _clientDal.GetClients(internalUserId);
        }

        public void UpdateClientTPLStatus(int clientId, TplStatus status, int internalUserId)
        {
            _clientDal.UpdateClientTPLStatus(clientId, status, internalUserId);
        }

        public void UpdateClientTPLTerm(int clientId, int tplTermId, int internalUserId)
        {
            _clientDal.UpdateClientTPLTerm(clientId, tplTermId, internalUserId);
        }
    }
}
