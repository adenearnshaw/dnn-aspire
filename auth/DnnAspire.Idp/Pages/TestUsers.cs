// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using IdentityModel;
using System.Security.Claims;
using System.Text.Json;
using Duende.IdentityServer;
using Duende.IdentityServer.Test;

namespace DnnAspire.Idp;

public class TestUsers
{
    public static List<TestUser> Users
    {
        get
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "ad6cca94-1eaf-49d2-851d-aca4f5b5868c",
                    Username = "alice",
                    Password = "alice",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Alice Smith"),
                        new Claim(JwtClaimTypes.GivenName, "Alice"),
                        new Claim(JwtClaimTypes.FamilyName, "Smith"),
                        new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    }
                },
                new TestUser
                {
                    SubjectId = "fbe8afca-1157-4e5a-af12-c6c73d27ea03",
                    Username = "bob",
                    Password = "bob",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Bob Smith"),
                        new Claim(JwtClaimTypes.GivenName, "Bob"),
                        new Claim(JwtClaimTypes.FamilyName, "Smith"),
                        new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    }
                }
            };
        }
    }
}