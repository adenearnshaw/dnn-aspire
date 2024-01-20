using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DnnAspire.Foodbanks.Web.Components.Pages
{
    public class LoginModel : PageModel
    {
        public async Task OnGet(string redirectUri)
        {
            await HttpContext.ChallengeAsync("oidc", new AuthenticationProperties { RedirectUri = redirectUri });
        }
    }
}
