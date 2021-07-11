using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.SessionStorage;

namespace pwaSepehr.AuthState
{
    public class myAuthStateProvider : AuthenticationStateProvider
    {
        private ISessionStorageService _sessionStorageService;
        public myAuthStateProvider(ISessionStorageService sessionStorageService)
        {
            _sessionStorageService = sessionStorageService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var username = await _sessionStorageService.GetItemAsync<string>("User");
            //await Task.Delay(2000);
            var user = new ClaimsIdentity();   // Anonymous User (UnAuthorized)
            if (!String.IsNullOrEmpty(username))
            {
                user = new ClaimsIdentity(new List<Claim>()     //Authenticated User
                {
                    new Claim(ClaimTypes.Name,username),
                    new Claim(ClaimTypes.Role,"Admin")
                }, "Test And Fake");
            }
            else
            {
                user = new ClaimsIdentity();   // Anonymous User (UnAuthorized)
            }

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(user)));

        }
        public async Task MarkUserAsAuthenticated(MyModels.myuser MyUser,string CompanyName)
        {
            //await Task.Delay(2000);
            
            var user = new ClaimsIdentity(new List<Claim>()     //Authenticated User
            {
                new Claim(ClaimTypes.Name,MyUser.UserName),
                new Claim(ClaimTypes.Role,"Admin")
            }, "Test And Fake");

            await _sessionStorageService.SetItemAsync<string>("User",MyUser.UserName.ToLower());
            await _sessionStorageService.SetItemAsync<string>("Company",CompanyName);
            await _sessionStorageService.SetItemAsync<string>("Year",MyUser.Year);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(user))));

        }
        public async Task MarkUserAsLogOuted()
        {
            await _sessionStorageService.RemoveItemAsync("User");
            await _sessionStorageService.RemoveItemAsync("Company");
            await _sessionStorageService.RemoveItemAsync("Year");
            await _sessionStorageService.RemoveItemAsync("Token");

            var anonymous = new ClaimsIdentity();   // Anonymous User (UnAuthorized)
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous))));

        }
    }
}
