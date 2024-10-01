using Microsoft.AspNetCore.Mvc;
using PIM.Models;
using System.Diagnostics;

//roda interação acontece na controller
namespace PIM.Controllers
{
    public class HomeController : Controller
    {

        //pagina index
        public IActionResult Index()
        {
            HomeModel home = new HomeModel();

            home.Nome = "Rodrigo";
            home.Email = "rodrigo@fsdsadas";
            return View(home);
            //esses dados vao interagir com a view
        }

        //pagina de privacidade
        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //metodo de erro
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
