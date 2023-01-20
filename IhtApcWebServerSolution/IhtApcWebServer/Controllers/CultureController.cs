using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;


namespace IhtApcWebServer.Controllers;

[Route("[controller]/[action]")]
public class CultureController : Controller
{
	public IActionResult Set(string newCulture, string redirectUri)
	{
		if (!string.IsNullOrWhiteSpace(newCulture))
		{
			var strDefaultCulture = "en-US";

			HttpContext.Response.Cookies.Append(
				CookieRequestCultureProvider.DefaultCookieName,
				CookieRequestCultureProvider.MakeCookieValue(
					new RequestCulture(strDefaultCulture, newCulture)));
		}

		return LocalRedirect(redirectUri);
	}
}
