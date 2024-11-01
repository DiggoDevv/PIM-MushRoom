using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PIM.Models;

namespace PIM.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            LoginModel login = JsonConvert.DeserializeObject<LoginModel>(sessaoUsuario);

            return View(login);
        }
    }
}
