using Aldagi.Common.Enums;
using Aldagi.Common.Exceptions;
using Aldagi.Common.Models;
using Aldagi.ThirdPartyLiability.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Aldagi.Common.Entities;

namespace Aldagi.ThirdPartyLiability.DAL.Concrete
{
    public class ClientDAL : IClientDAL
    {
        private readonly DatabaseContext _databaseContext;
        public ClientDAL(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public void AddClient(ClientRegistrationModel clientRegistration, int internalUserId)
        {
            var client = new Entities.Client()
            {
                FirstName = clientRegistration.FirstName,
                LastName = clientRegistration.LastName,
                PersonalId = clientRegistration.PersonalId,
                ClientDetails = new Entities.ClientDetails()
                {
                    InternalUserId = internalUserId,
                    CarRegistrationNumber = clientRegistration.CarRegistrationNumber,
                    DateOfBirth = clientRegistration.DateOfBirth,
                    Email = clientRegistration.Email,
                    PhoneNumber = clientRegistration.PhoneNumber,
                    Image = clientRegistration.Image,
                    CarId = clientRegistration.CarId,
                    TPLDetails = new Entities.TPLDetails()
                    {
                        TPLTermId = clientRegistration.LiabilityTermId,
                        Status = TplStatus.Unpaid
                    }
                }
            };
            _databaseContext.Clients.Add(client);
            _databaseContext.SaveChanges();
        }

        public void DeleteClientTPL(int clientId, int internalUserId)
        {
            var clientTplDetails = _databaseContext.Clients.Include(c => c.ClientDetails).ThenInclude(t => t.TPLDetails).Where(x => x.ClientId == clientId).FirstOrDefault().ClientDetails.TPLDetails;
            _databaseContext.TPLDetails.Remove(clientTplDetails);
            _databaseContext.SaveChanges();
        }

        public ClientDetails GetClientDetails(int clientId, int internalUserId)
        {
            var clientDetails = _databaseContext.Clients.Include(c => c.ClientDetails).Where(x => x.ClientId == clientId && x.ClientDetails.InternalUserId == internalUserId).FirstOrDefault().ClientDetails;
            return new ClientDetails()
            {
                CarId = clientDetails.CarId,
                CarRegistrationNumber = clientDetails.CarRegistrationNumber,
                ClientDetailsId = clientDetails.ClientDetailsId,
                DateOfBirth = clientDetails.DateOfBirth,
                Email = clientDetails.Email,
                Image = clientDetails.Image,
                PhoneNumber = clientDetails.PhoneNumber,
                LiabilityDetailsId = clientDetails.TPLDetailsId
            };
        }

        public IEnumerable<Client> GetClients(int internalUserId)
        {
            var clients = _databaseContext.Clients.Where(x => x.ClientDetails.InternalUserId == internalUserId).ToList();

            return clients.Select(client =>
            {
                return new Client()
                {
                    ClientDetailsId = client.ClientDetailsId,
                    ClientId = client.ClientId,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    PersonalId = client.PersonalId
                };
            });
        }

        public void UpdateClientTPLTerm(int clientId, int tplTermId, int internalUserId)
        {
            var clientTpl = _databaseContext.Clients.Include(c => c.ClientDetails).ThenInclude(t => t.TPLDetails).Where(x => x.ClientId == clientId).FirstOrDefault().ClientDetails.TPLDetails;

            if (clientTpl == null)
            {
                _databaseContext.Clients.Include(c => c.ClientDetails).ThenInclude(t => t.TPLDetails).Where(x => x.ClientId == clientId).FirstOrDefault().ClientDetails.TPLDetails = new Entities.TPLDetails()
                {
                    TPLTermId = tplTermId
                };
            }
            else
                clientTpl.TPLTermId = tplTermId;
            _databaseContext.SaveChanges();
        }

        public void UpdateClientTPLStatus(int clientId, TplStatus status, int internalUserId)
        {
            var clientTpl = _databaseContext.Clients.Include(c => c.ClientDetails).ThenInclude(t => t.TPLDetails).Where(x => x.ClientId == clientId).FirstOrDefault().ClientDetails.TPLDetails;
            if (clientTpl == null)
            {
                _databaseContext.Clients.Include(c => c.ClientDetails).ThenInclude(t => t.TPLDetails).Where(x => x.ClientId == clientId).FirstOrDefault().ClientDetails.TPLDetails = new Entities.TPLDetails()
                {
                    TPLTermId = 0,
                    Status = status
                };
            }
            else
                clientTpl.Status = status;
            _databaseContext.SaveChanges();
        }

        public LiabilityDetails GetClientLiability(int clientId, int internalUserId)
        {
            var details = _databaseContext.Clients
                .Include(c => c.ClientDetails)
                .ThenInclude(d => d.TPLDetails)
                .FirstOrDefault(client => client.ClientId == clientId && client.ClientDetails.InternalUserId == internalUserId).ClientDetails.TPLDetails;

            if (details == null)
            {
                throw new DalException();
            }
            else
                return new LiabilityDetails()
                {
                    Status = details.Status,
                    LiabilityDetailsId = details.TplDetailsId,
                    LiabilityTermId = details.TPLTermId
                };

        }

        public TplStatus GetClientLiabilityStatus(int clientId, int internalUserId)
        {
            var details = _databaseContext.Clients
                .Include(c => c.ClientDetails)
                .ThenInclude(d => d.TPLDetails)
                .FirstOrDefault(client => client.ClientId == clientId && client.ClientDetails.InternalUserId == internalUserId).ClientDetails.TPLDetails;
            if (details == null)
                throw new DalException();
            return details.Status;
        }
    }
}
