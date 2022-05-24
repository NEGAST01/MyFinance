using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Models;


namespace MyFinance.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public IActionResult Login(int? id)
        {
            if(id != null)
            {
                if (id == 0)
                {
                    HttpContext.Session.SetString("IDUsuarioLogado", string.Empty);
                    HttpContext.Session.SetString("NomeUsuarioLogado", string.Empty);

                }

            }

            return View();
        }

        [HttpPost]
        public IActionResult ValidarLogin(UsuarioModel usuario)
        {

            bool Login = usuario.ValidarLogin();
            if (Login == true)
            {
                HttpContext.Session.SetString("NomeUsuarioLogado", usuario.Name);
                HttpContext.Session.SetString("IDUsuarioLogado", usuario.Id.ToString());
                return RedirectToAction("Menu", "Home");

            }
            else
            {
                TempData["MessagemLoginInvalido"] = "Dados de Login Inválidos"; 
                return RedirectToAction("Login");


            }

        }
        [HttpPost]
       
        public IActionResult Registrar(UsuarioModel usuario)
        {
            if (ModelState.IsValid){

                usuario.RegistrarUsuario();
                return RedirectToAction("Sucesso");


            }                              
            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();

        }
        public IActionResult Sucesso()
        {
            return View();

        }
    }
}
