﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "oauthClient",
                    ClientName = "Example client application using client credentials",
                    ClientSecrets = new List<Secret>{ new Secret("SuperSecretPassword".Sha256())},

                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string>{"https://localhost:5002/signin-oidc"},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        "api1.read"
                    },
                    RequirePkce = true,
                    AllowPlainTextPkce = false
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "customAPI",
                    DisplayName = "API #1",
                    Description = "Allow the application to access API #1 on your behalf",
                    Scopes = new List<string> {"api1.read", "api1.write"},
                    ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope("api1.read", "Read Access to API #1"),
                new ApiScope("api1.write", "Write Access to API #1")
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser> {
                new TestUser {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "scott",
                    Password = "password",
                    Claims = new List<Claim> {
                        new Claim(JwtClaimTypes.Email, "scott@scottbrady91.com"),
                        new Claim(JwtClaimTypes.Role, "admin")
                    }
                }
            };
        }
    }
}
