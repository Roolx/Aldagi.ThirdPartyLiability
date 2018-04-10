using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aldagi.ThirdPartyLiability.Identity
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
                {
                     new ApiResource("tplApi", "Aldagi Thirdparty Liability API")
                };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "testClient",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    Claims = {
                       new System.Security.Claims.Claim("identityUserId","1")
                    },

                    AllowedScopes = { "tplApi" }
                },
                new Client()
                {
                    ClientId = "adminClient",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                     Claims = {
                       new System.Security.Claims.Claim("identityUserId","1")
                    },

                     AlwaysSendClientClaims = true,

                    AllowedScopes = { "tplApi" }
                }
            };

        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "2",
                    Username = "admin",
                    Password = "123"
                }
            };
        }
    }
}
