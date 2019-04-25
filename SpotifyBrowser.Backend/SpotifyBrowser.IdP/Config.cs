using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using SpotifyBrowser.Application.Shared.Auth;
namespace SpotifyBrowser.IdP
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource(Constants.SpotifyBrowserReadApiName, Constants.SpotifyBrowserReadApiName),
                new ApiResource(Constants.SpotifyBrowserWriteApiName, Constants.SpotifyBrowserWriteApiName),
                new ApiResource(Constants.SpotifyBrowserReadUsersApiName, Constants.SpotifyBrowserReadUsersApiName),
                new ApiResource(Constants.SpotifyBrowserWriteUsersApiName, Constants.SpotifyBrowserWriteUsersApiName)
            };
        }

        public static IEnumerable<Client> GetClients(string spotifyWebClientRootUrl)
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = Constants.SpotifyBrowserClientId,
                    ClientName = Constants.SpotifyBrowserClientName,
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    RedirectUris =           { $"{spotifyWebClientRootUrl}assets/oidc-login-redirect.html",$"{spotifyWebClientRootUrl}assets/silent-redirect.html" },
                    PostLogoutRedirectUris = { $"{spotifyWebClientRootUrl}?postLogout=true" },
                    AllowedCorsOrigins =     { $"{spotifyWebClientRootUrl}" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        Constants.SpotifyBrowserReadApiName,
                        Constants.SpotifyBrowserWriteApiName,
                        Constants.SpotifyBrowserReadUsersApiName,
                        Constants.SpotifyBrowserWriteUsersApiName
                    },
                    IdentityTokenLifetime=120,
                    AccessTokenLifetime=120

                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
            {
                return new List<IdentityResource>
                {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Profile()
                };
            }
        }
    }